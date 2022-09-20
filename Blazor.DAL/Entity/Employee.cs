using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.DAL.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "This is too long name!!!")]
        public string FirstName { get; set; } = "";
        [Required]
        [StringLength(10, ErrorMessage = "This is too long name!!!")]
        public string LastName { get; set; } = "";

        public string Email { get; set; } = "";
        public DateTime BirthDate { get; set; }

        
        public string PhoneNumber { get; set; } = "";

        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public string State { get; set; }

        public string Gender { get; set; }

        

    }
}
