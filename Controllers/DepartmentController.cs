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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _dr;
        public DepartmentController(IDepartmentRepo dr)
        {
            _dr = dr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeps()
        {
            var deps = await _dr.GetAllDeps();

            if (!deps.Any()) return BadRequest("No Departments");

            var veiwDeps = deps.Select(x => new ReadDepartmentDTO
            {
                Name = x.Name,
                Location = x.Location,
                emps = x.employees.Any() ? x.employees.Select(x => new EmployeeDetailsPriefDTO
                {
                    Name = x.Name,
                    Email = x.Email,
                }).ToList() : null,
            }).ToList();

            return Ok(veiwDeps);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDep([FromRoute] int id)
        {
            var dep = await _dr.GetDepById(id);

            if (dep == null) return BadRequest("Invalid Id");

            if (dep.employees != null) return BadRequest("Employee(s) Assigned");

            await _dr.Delete(dep);

            return Ok("Done!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDep([FromRoute] int id, [FromBody] UpdateDepartmentDTO newdep)
        {
            var dep = await _dr.GetDepById(id);

            if (dep == null) return BadRequest("Invalid Id");

            dep.Id = id;
            dep.Name = newdep.Name;
            dep.Location = newdep.Location;

            await _dr.Update(dep);

            return Ok("Done!");
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateDep([FromBody] UpdateDepartmentDTO newdep)
        {
            var dep = new Department { };

            dep.Name = newdep.Name;
            dep.Location = newdep.Location;

            await _dr.Create(dep);

            return Ok("Done!");
        }
    }
}