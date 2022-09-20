using Blazor.BL.Interface;
using Blazor.BL.Model;
using Blazor.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor.BL.Repository
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient httpClient;

        public EmployeeDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<EmployeeVM>> GetAllEmployee()
        {
            var data = await JsonSerializer.DeserializeAsync<IEnumerable<EmployeeVM>>
                (await httpClient.GetStreamAsync("/api/GetAllEmployee"), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
            return data;
        }

        public async Task<EmployeeVM> GetEmployee(int Id)
        {
            var data = await JsonSerializer.DeserializeAsync<EmployeeVM>
                (await httpClient.GetStreamAsync("/api/GetEmployee/"+Id), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });

            return data;
        }
        public async Task AddEmployee(EmployeeVM data)
        {
            var empObjSer = new StringContent(JsonSerializer.Serialize(data),
                Encoding.UTF8, "application/json");

            await httpClient.PostAsync("/api/AddEmployee/", empObjSer);
        }
        public async Task UpdateEmployee(EmployeeVM data)
        {
            var empObjSer = new StringContent(JsonSerializer.Serialize(data),
                Encoding.UTF8, "application/json");

            await httpClient.PutAsync("/api/UpdateEmployee", empObjSer);
        }

       

        public async Task DeleteEmployee(int Id)
        {
            await httpClient.DeleteAsync("/api/DeleteEmployee/"+Id);
        }


      
    }
}
