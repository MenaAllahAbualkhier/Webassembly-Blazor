using Blazor.BL.Interface;
using Blazor.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor.BL.Repository
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient httpClient;
        public CountryDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<CountryVM>> GetAllCountry()
        { 
            var data = await JsonSerializer.DeserializeAsync<IEnumerable<CountryVM>>
                (await httpClient.GetStreamAsync("/api/GetAllCountry"), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
            return data;
        }

        public async Task<CountryVM> GetCountry(int Id)
        {
            var data = await JsonSerializer.DeserializeAsync<CountryVM>
               (await httpClient.GetStreamAsync("/api/GetCountry/"+Id), new JsonSerializerOptions()
               { PropertyNameCaseInsensitive = true });
            return data;
        }
    }
}
