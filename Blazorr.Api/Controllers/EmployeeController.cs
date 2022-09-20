using AutoMapper;
using Blazor.BL.Model;
using Blazor.DAL.DataBase;
using Blazor.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly DemoDb db;

        public EmployeeController(IMapper mapper, DemoDb db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        [HttpGet]
        [Route("~/api/GetAllEmployee")]

        public async Task<IEnumerable<EmployeeVM>> GetAllEmployee()
        {
            var data = await db.Employee.ToListAsync();
            var model=mapper.Map<IEnumerable<EmployeeVM>>(data);   
            return model;
        }

        [HttpGet]
        [Route("~/api/GetEmployee/{Id}")]
        public async Task<EmployeeVM> GetEmployee(int Id)
        {
            var data= await db.Employee.FirstOrDefaultAsync(a=>a.Id==Id);
            var  model= mapper.Map<EmployeeVM>(data);
            return model;
        }

        [HttpPost]
        [Route("~/api/AddEmployee")]
        public async Task AddEmployee(EmployeeVM data)
        {
            var model = mapper.Map<Employee>(data);
            await db.Employee.AddAsync(model);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("~/api/UpdateEmployee")]
        public async Task UpdateEmployee(EmployeeVM data)
        {
            var model=mapper.Map<Employee>(data);
            db.Update(model);
            db.SaveChanges();
        }

        [HttpDelete]
        [Route("~/api/DeleteEmployee/{Id}")]
        public async Task  DeleteEmployee(int Id)
        {
            var model = db.Employee.Find(Id);
             db.Remove(model);
            db.SaveChanges();
        }
    }
}
