using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company_Management_System.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public Department? department { get; set; }
        public Contract? contract { get; set; }
        public IList<EmployeeProject> projects { get; set; }
    }
}

