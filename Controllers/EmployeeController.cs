using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company_Management_System.DTOs;
using Company_Management_System.Models;
using Company_Management_System.Repos_Interfaces.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _er;
        private readonly IDepartmentRepo _dr;
        public EmployeeController(IEmployeeRepo er , IDepartmentRepo dr)
        {
            _er = er;
            _dr = dr;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmps()
        {
            var emps = await _er.GetEmpDepConPro();

            if (!emps.Any()) return NotFound("No Emps Found");

            var veiwRes = emps.Select(x => new ReadEmployeeDTO
            {
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                DeparmentName = x.department.Name,
                ContractNum = x.contract == null ? "Not Available" : x.contract.ContractNumber,
                ProjectNames = x.projects.Any() ? x.projects.Select(x => x.project.ProjectName).ToList() : null,
            });

            return Ok(veiwRes);
        }

        [HttpGet("Projects count per emp")]
        public async Task<IActionResult> GetEmps2()
        {
            var emps = await _er.GetEmpDepConPro();

            if (!emps.Any()) return NotFound("No Emps Found");

            var veiwRes = emps.Select(x => new ReadEmployeeDetailsDTO
            {
                Name = x.Name,
                ContractNum = x.contract.ContractNumber,
                ProjectCount = x.projects.Any() ? x.projects.Count : 0,
            });

            return Ok(veiwRes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmp([FromRoute] int id)
        {
            var emp = await _er.GetEmpById(id);

            if (emp == null) return BadRequest("Invalid Id");

            if (emp.projects.Any()) return BadRequest("Assigned To Project");

            await _er.Delete(emp);

            return Ok("Done!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmp([FromRoute] int id, [FromBody] UpdateEmployeeDTO newEmp)
        {
            var emp = await _er.GetEmpById(id);

            if (emp == null) return BadRequest("Invalid Id");
            emp.Id = id;
            if (!string.IsNullOrWhiteSpace(newEmp.Name)) { emp.Name = newEmp.Name; }
            if (!string.IsNullOrWhiteSpace(newEmp.Phone)) { emp.Phone = newEmp.Phone; }
            if (!string.IsNullOrWhiteSpace(newEmp.Email)) 
            {
                var Echeck = await _er.GetEmpByEmail(newEmp.Email);

                if (Echeck != null) return BadRequest("Email Already Exists");

                emp.Email = newEmp.Email; 
            }
            if (!string.IsNullOrWhiteSpace(newEmp.DeparmentName))
            {
                var dep = await _dr.GetDepByName(newEmp.DeparmentName);

                if (dep == null) return BadRequest("Invalid Department Name");

                emp.department = dep;
                emp.DepartmentId = dep.Id;
            }

            await _er.Update(emp);

            return Ok("Done!");
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEmp([FromBody] UpdateEmployeeDTO newEmp)
        {
            var emp = new Employee{ };

            if (emp == null) return BadRequest("Invalid Id");

            emp.Name = newEmp.Name;
            emp.Phone = newEmp.Phone;

            var Echeck = await _er.GetEmpByEmail(newEmp.Email);

            if (Echeck != null) return BadRequest("Email Already Exists");

            emp.Email = newEmp.Email;

            var dep = await _dr.GetDepByName(newEmp.DeparmentName);  
            
            if (dep == null) return BadRequest("Invalid Department Name");

            emp.department = dep;
            emp.DepartmentId = dep.Id;
            

            await _er.Create(emp);

            return Ok("Done!");
        }
    }
}