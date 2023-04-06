using PayrollSystem.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace PayrollSystem.Models
{
    public class EmployeeDetailViewModel
    {
            
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ".").ToUpper()) + " " + LastName; }
        }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
        public string Role { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "NationalInsuranceNo is required"), StringLength(50), Display(Name = "NI No"), RegularExpression(@"^[A-CEGHJ-PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9]{6}[A-D\s]$")]
        public string NationalInsuranceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }


    }
}

    