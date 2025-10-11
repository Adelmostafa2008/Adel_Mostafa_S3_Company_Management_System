using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company_Management_System.Models;

namespace Company_Management_System.Repos_Interfaces.interfaces
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {
        Task<IList<Employee>> GetEmpDepConPro();
        Task<Employee> GetEmpById(int id);
        Task<Employee> GetEmpByEmail(string Email);
    }
}