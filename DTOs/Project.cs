using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_Management_System.DTOs
{
    public class UpdateProjectDTO
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal Budget { get; set; }
    }
    public class CreateProjectDTO
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal Budget { get; set; }
    }
    public class ReadProjectDTO
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndTime { get; set; }
        public int EmployeeCount { get; set; }
        public IList<EmployeeDetailsPriefDTO>? employees { get; set; }
    }
}