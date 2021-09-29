using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace SpecFlowWithFixtures.Specs.Apis
{
    public interface IOpenBreweryDbSearchApi
    {
        [Get("/breweries?by_dist={location}")]
        Task<IEnumerable<Brewery>> SearchBreweriesByLocation(string location);
    }
}