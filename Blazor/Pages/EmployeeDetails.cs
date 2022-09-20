using Blazor.BL.Interface;
using Blazor.BL.Model;
using Blazor.DAL.Entity;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages
{
    public partial class EmployeeDetails
    {
        [Parameter]
        public int Id { get; set; }
        public EmployeeVM? curEmp { get; set; }

        public CountryVM? country { get; set; }

        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }

        [Inject]
        public ICountryDataService countryDataService { get; set; }

        [Inject]
        public NavigationManager? navigationManager { get; set; }
        protected  override async Task OnInitializedAsync()
        {
            curEmp = await employeeDataService.GetEmployee(Id);
            country = await countryDataService.GetCountry(curEmp.CountryId);


        }
        public async Task Delete_Click()
        {
            await employeeDataService.DeleteEmployee(curEmp.Id);
            navigationManager.NavigateTo("/EmployeeOverView");
        }


    }
}
