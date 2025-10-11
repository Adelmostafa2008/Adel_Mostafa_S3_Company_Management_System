using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_Management_System.DTOs
{
    public class ReadDepartmentDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public IList<EmployeeDetailsPriefDTO>? emps { get; set; }
    }
    
    public class UpdateDepartmentDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}