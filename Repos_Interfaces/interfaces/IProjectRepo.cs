using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company_Management_System.Models;
using Microsoft.Build.Framework;

namespace Company_Management_System.Repos_Interfaces.interfaces
{
    public interface IProjectRepo : IGenericRepo<Project>
    {
        Task<Project> GetProById(int id);
        Task<IList<Project>> GetAllPros();
    }
}