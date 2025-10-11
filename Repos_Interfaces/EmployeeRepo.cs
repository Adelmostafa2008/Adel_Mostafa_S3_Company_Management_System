using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company_Management_System.Data;
using Company_Management_System.Models;
using Company_Management_System.Repos_Interfaces.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Company_Management_System.Repos_Interfaces
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(AppDb _db) : base(_db)
        {
            
        }

        public async Task<Employee> GetEmpByEmail(string Email)
        {
            var emp = await _db.employee.FirstOrDefaultAsync(x => x.Email == Email);
            return emp;
        }

        public async Task<Employee> GetEmpById(int id)
        {
            var emp = await _db.employee.Include(x => x.projects).Include(x => x.contract).FirstOrDefaultAsync(x => x.Id == id);
            return emp;
        }

        public async Task<IList<Employee>> GetEmpDepConPro()
        {
            var res = await _db.employee.Include(x => x.contract).Include(x=>x.department).Include(x => x.department).Include(x => x.projects).ThenInclude(x => x.project).ToListAsync();

            return res;
        }
    }
}