using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Models
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Tax ID")]
        public string TaxId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }
    }
}
