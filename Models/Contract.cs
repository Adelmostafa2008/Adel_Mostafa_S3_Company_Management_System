using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Company_Management_System.Models
{
    [Index(nameof(ContractNumber) , IsUnique = true)]
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContractNumber { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required, Range(1, int.MaxValue)]
        public decimal Salary { get; set; }
        public int? EmployeeId { get; set; }
        public Employee ? employee  { get; set; }
    }
}

