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
    public class ContractRepo : GenericRepo<Contract> , IContractRepo
    {
        public ContractRepo(AppDb _db) : base(_db)
        {
            
        }

        public async Task<Contract> GetContById(int id)
        {
            return await _db.contract.Include(x => x.employee).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}