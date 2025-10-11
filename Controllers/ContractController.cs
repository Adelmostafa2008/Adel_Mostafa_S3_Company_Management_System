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
    public class ContractController : ControllerBase
    {
        private readonly IContractRepo _cr;
        private readonly IEmployeeRepo _er;
        public ContractController(IContractRepo cr , IEmployeeRepo er)
        {
            _er = er;
            _cr = cr;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCont([FromRoute] int id)
        {
            var cont = await _er.GetEmpById(id);

            if (cont == null || cont.contract == null) return NotFound("Invalid Id");

            var veiwRes = new ReadContractDTO
            {
                EmpName = cont.Name,
                ContractNumber = cont.contract.ContractNumber,
                Salary = cont.contract.Salary,
                StartDate = cont.contract.StartDate,
                EndDate = cont.contract.EndDate,
            };

            return Ok(veiwRes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCont([FromBody] CreateContractDTO newCont)
        {

            var emp = await _er.GetEmpByEmail(newCont.EmpEmail);

            if (emp == null) return BadRequest("Invalid Email");

            var cont = new Contract
            {
                ContractNumber = newCont.ContractNumber,
                EndDate = newCont.EndDate,
                Salary = newCont.Salary,
                StartDate = newCont.StartDate,
                employee = emp,
                EmployeeId = emp.Id,
            };

            await _cr.Create(cont);

            return Ok("Done!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCont([FromRoute] int id, UpdateContractDTO newCont)
        {
            var cont = await _cr.GetById(id);

            if (cont == null) return BadRequest("Invalid Id");

            cont.Id = id;
            cont.StartDate = newCont.StartDate;
            cont.EndDate = newCont.EndDate;
            cont.Salary = newCont.Salary;

            await _cr.Update(cont);

            return Ok("Done!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCont([FromRoute] int id)
        {
            var cont = await _cr.GetContById(id);

            if (cont == null) return NotFound("Invalid Id");

            if (cont.employee != null) return BadRequest("Employee Assigned");

            await _cr.Delete(cont);

            return Ok("Done!"); 
        }
    }
}