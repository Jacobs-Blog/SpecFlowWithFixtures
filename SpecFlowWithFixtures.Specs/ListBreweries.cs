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
    public class ListBreweries
    {
        private const string Breweries = "BREWERIES";
        
        private readonly ScenarioContext _scenarioContext;
        private readonly RefitFixture<IOpenBreweryDbListApi> _refitFixture;
        private readonly SettingsFixture _settingsFixture;

        public ListBreweries(
            ScenarioContext scenarioContext,
            RefitFixture<IOpenBreweryDbListApi> refitFixture,
            SettingsFixture settingsFixture)
        {
            _scenarioContext = scenarioContext;
            _refitFixture = refitFixture;
            _settingsFixture = settingsFixture;
        }

        [Given("I open the application")]
        public void GivenIOpenTheApplication()
        {
            // Leave empty
        }

        [When("opening the list page")]
        public async Task WhenOpeningTheListPage()
        {
            var breweries = await _refitFixture
                .GetRestClient(_settingsFixture.AppSettings.BaseAddress)
                .GetBreweryList();
            _scenarioContext.Add(Breweries, breweries);
        }

        [Then("a list of breweries should be available")]
        public void ThenAListOfBreweriesShouldBeAvailable()
        {
            var breweries = _scenarioContext.Get<IEnumerable<Brewery>>(Breweries);
            Assert.NotEmpty(breweries);
        }
    }
}