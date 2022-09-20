using AutoMapper;
using Blazor.BL.Model;
using Blazor.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee,EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();


            CreateMap<IdentityUser, RegistrationVM>();
            CreateMap<RegistrationVM, IdentityUser>();
        }
    }
}
