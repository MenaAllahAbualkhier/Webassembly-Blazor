using Blazor.BL.Model;
using Blazor.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.Interface
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<EmployeeVM>> GetAllEmployee();
        Task<EmployeeVM> GetEmployee(int Id);
        Task AddEmployee(EmployeeVM data);
        Task UpdateEmployee(EmployeeVM data);

        Task DeleteEmployee(int Id);


    }
}
