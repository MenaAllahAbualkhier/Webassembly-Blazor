using Blazor.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.DAL.DataBase
{
    public class DemoDb:IdentityDbContext
    {
        public DemoDb(DbContextOptions<DemoDb> opt) : base(opt)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }

    }
}
