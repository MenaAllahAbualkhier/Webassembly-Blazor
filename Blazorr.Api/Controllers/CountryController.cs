using AutoMapper;
using Blazor.BL.Model;
using Blazor.DAL.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly DemoDb db;

        public CountryController(IMapper mapper, DemoDb db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        [HttpGet]
        [Route("~/api/GetAllCountry")]

        public async Task<IEnumerable<CountryVM>> GetAllCountry()
        {
            var data = await db.Country.ToListAsync();
            var model = mapper.Map<IEnumerable<CountryVM>>(data);
            return model;
        }
        [HttpGet]
        [Route("~/api/GetCountry/{Id}")]

        public async Task<CountryVM> GetCountry(int Id)
        {
            var data = await db.Country.FirstOrDefaultAsync(a => a.CountryId == Id);
            var model = mapper.Map<CountryVM>(data);
            return model;
        }
    }
}
