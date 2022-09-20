using Blazor.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.Interface
{
    public interface ICountryDataService
    {
        Task<IEnumerable<CountryVM>> GetAllCountry();
        Task<CountryVM> GetCountry(int Id);
    }
}
