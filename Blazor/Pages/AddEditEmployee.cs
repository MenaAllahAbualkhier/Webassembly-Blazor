using Blazor.BL.Interface;
using Blazor.BL.Model;
using Blazor.DAL.Entity;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages
{
    public partial class AddEditEmployee
    {
        [Parameter]
        public int Id { get; set; }
        public EmployeeVM Employee { get; set; }
        IEnumerable<CountryVM>? countries;

        [Inject]
        public IEmployeeDataService employeeDataService { get; set; }
        [Inject]
        public ICountryDataService countryDataService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public string message = "";
        public string messageClass = "";

        protected override async Task OnInitializedAsync()
        {
            countries = await countryDataService.GetAllCountry();
            if (Id == 0)
            {
                Employee = new EmployeeVM { CountryId = 1, BirthDate = DateTime.Now };
            }
            else
            {
                Employee = await employeeDataService.GetEmployee(Id);
            }
        }

        public bool saved;
        protected async void HandleValidSubmit()
        {
            if (Employee.Id == 0)
            {
                await employeeDataService.AddEmployee(Employee);
                navigationManager.NavigateTo("/EmployeeOverView");

            }
            else
            {
                await employeeDataService.UpdateEmployee(Employee);
                message = "Employee Updated successfully";
                messageClass = "alert alert-success ";
                saved = true;
            }
        }
        protected void HandleInvalidSubmit()
        {
            message = "Some error Happened";
            messageClass = "alert alert-danger ";
            saved = true;
        }
    }
}
