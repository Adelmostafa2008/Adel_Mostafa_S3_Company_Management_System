using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company_Management_System.Models;

namespace Company_Management_System.Repos_Interfaces.interfaces
{
    public interface IContractRepo : IGenericRepo<Contract>
    {
        Task<Contract> GetContById(int id);
    }
}