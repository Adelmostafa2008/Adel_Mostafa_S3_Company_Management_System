using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Company_Management_System.Models
{
    [Index(nameof(Name) , IsUnique = true)]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public IList<Employee> ? employees { get; set; }
    }
}
