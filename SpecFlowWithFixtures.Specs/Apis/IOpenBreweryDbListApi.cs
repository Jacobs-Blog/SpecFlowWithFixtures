using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace SpecFlowWithFixtures.Specs.Apis
{
    public interface IOpenBreweryDbListApi
    {

        [Get("/breweries")]
        Task<IEnumerable<Brewery>> GetBreweryList();
    }
}