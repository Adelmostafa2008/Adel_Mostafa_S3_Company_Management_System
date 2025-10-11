using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company_Management_System.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndTime { get; set; }
        [Range(1, int.MaxValue)]
        public decimal Budget { get; set; }
        public IList<EmployeeProject> employees {   get; set; }
    }
}

