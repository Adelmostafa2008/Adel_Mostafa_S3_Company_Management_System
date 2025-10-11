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
    public class ProjectRepo : GenericRepo<Project> , IProjectRepo
    {
        public ProjectRepo(AppDb _db) : base(_db)
        {
            
        }

        public async Task<IList<Project>> GetAllPros()
        {
            return await _db.project.Include(x => x.employees).ThenInclude(x => x.employee).ToListAsync();
        }

        public async Task<Project> GetProById(int id)
        {
            return await _db.project.Include(x => x.employees).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}