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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepo _pr;
        public ProjectController(IProjectRepo pr)
        {
            _pr = pr;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePro([FromRoute] int id)
        {
            var pro = await _pr.GetProById(id);

            if (pro == null) return NotFound("Invalid Id");

            if (pro.employees.Any()) return BadRequest("Employees Assigned");

            await _pr.Delete(pro);

            return Ok("Done!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePro([FromRoute] int id, UpdateProjectDTO newPro)
        {
            var pro = await _pr.GetProById(id);

            if (pro == null) return NotFound("Invalid Id");

            pro.Id = id;
            pro.Budget = newPro.Budget;
            pro.StartDate = newPro.StartDate;
            pro.ProjectName = newPro.ProjectName;
            pro.EndTime = newPro.EndTime;

            await _pr.Update(pro);

            return Ok("Done!");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePro([FromBody] CreateProjectDTO newPro)
        {
            var pro = new Project
            {
                Budget = newPro.Budget,
                EndTime = newPro.EndTime,
                ProjectName = newPro.ProjectName,
                StartDate = newPro.StartDate,
            };

            await _pr.Create(pro);

            return Ok("Done!");
        }

        [HttpGet]
        public async Task<IActionResult> GetPros()
        {
            var pros = await _pr.GetAllPros();

            if (pros == null) return NotFound("No Projects Available");

            var veiwPro = pros.Select(x => new ReadProjectDTO
            {
                ProjectName = x.ProjectName,
                StartDate = x.StartDate,
                EndTime = x.EndTime,
                EmployeeCount = x.employees.Any() ? x.employees.Count : 0,
                employees = x.employees.Any() ? x.employees.Select(x => new EmployeeDetailsPriefDTO
                {
                    Name = x.employee.Name,
                    Email = x.employee.Email,
                }).ToList() : null,
            });

            return Ok(veiwPro);
        }
    }
}