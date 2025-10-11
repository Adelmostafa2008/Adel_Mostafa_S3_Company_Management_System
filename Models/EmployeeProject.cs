using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_Management_System.Models
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
        public int ProjectId { get; set; }
        public Project project { get; set; }
    }
}