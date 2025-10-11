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
    public class DepartmentRepo : GenericRepo<Department> , IDepartmentRepo
    {
        public DepartmentRepo(AppDb _db) : base(_db)
        {
            
        }

        public async Task<IList<Department>> GetAllDeps()
        {
            return await _db.department.Include(x => x.employees).OrderByDescending(x => x.employees.Count).ToListAsync();
        }

        public async Task<Department> GetDepById(int id)
        {
            return await _db.department.Include(x => x.employees).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Department> GetDepByName(string Name)
        {
            return await _db.department.FirstOrDefaultAsync(x => x.Name == Name);
        }
    }
}