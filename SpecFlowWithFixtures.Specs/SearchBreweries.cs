using System.Collections.Generic;
using System.Threading.Tasks;
using SpecFlowWithFixtures.Specs.Apis;
using SpecFlowWithFixtures.Specs.Fixtures;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowWithFixtures.Specs
{
[Binding]
[Collection("Settings collection")]
public class SearchBreweries : RefitFixture<IOpenBreweryDbSearchApi>
{
    private const string Location = "LOCATION";
    private const string Breweries = "BREWERIES";
    
    private readonly ScenarioContext _scenarioContext;
    private readonly RefitFixture<IOpenBreweryDbSearchApi> _refitFixture;
    private readonly SettingsFixture _settingsFixture;

    public SearchBreweries(
        ScenarioContext scenarioContext, 
        RefitFixture<IOpenBreweryDbSearchApi> refitFixture,
        SettingsFixture settingsFixture)
    {
        _scenarioContext = scenarioContext;
        _refitFixture = refitFixture;
        _settingsFixture = settingsFixture;
    }

    [Given("my current location is \"(.*)\"")]
    public void GivenMyCurrentLocation(string location) =>
        _scenarioContext.Add(Location, location);

    [When("searching for breweries closeby")]
    public async Task WhenSearchingForBreweriesCloseby()
    {
        var breweries = await _refitFixture
            .GetRestClient(_settingsFixture.AppSettings.BaseAddress)
            .SearchBreweriesByLocation(_scenarioContext.Get<string>(Location));
        _scenarioContext.Add(Breweries, breweries);
    }

    [Then("a list of breweries should be returned")]
    public void ThenAListOfBreweriesShouldBeReturned()
    {
        var breweries = _scenarioContext.Get<IEnumerable<Brewery>>(Breweries);
        Assert.NotEmpty(breweries);
    }
}
}