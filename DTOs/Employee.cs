using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_Management_System.DTOs
{
    public class ReadEmployeeDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DeparmentName { get; set; }
        public string ContractNum { get; set; }
        public IList<string> ProjectNames { get; set; }
    }
    public class ReadEmployeeDetailsDTO
    {
        public string Name { get; set; }
        public string ContractNum { get; set; }
        public int ProjectCount { get; set; }
    }

    public class UpdateEmployeeDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? DeparmentName { get; set; } = string.Empty;
    }

    public class EmployeeDetailsPriefDTO
    {
        public string Name { get; set; } 
        public string Email { get; set; } 
    }
}