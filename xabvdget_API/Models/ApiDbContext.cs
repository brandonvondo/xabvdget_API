using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace xabvdget_API.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
            : base("DefaultConnection")
        {
        }

        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetHouseholdData").ToListAsync();
        }

        public async Task<Household> GetHouseholdDataById(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDataById", new SqlParameter("Id", hhId)).FirstOrDefaultAsync();
        }

        public async Task<List<Budget>> GetBudgetDataByHouseholdId(int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataByHouseholdId", new SqlParameter("Id", hhId)).ToListAsync();
        }

        public async Task<Budget> GetBudgetDataById(int Id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataById", new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetItem>> GetBudgetItemDataByBudgetId(int bId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDataByBudgetId", new SqlParameter("Id", bId)).ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDataById(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDataById", new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        public async Task<List<BankAccount>> GetBankAccountDataByHouseholdId(int hhId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDataByHouseholdId", new SqlParameter("Id", hhId)).ToListAsync();
        }

        public async Task<BankAccount> GetBankAccountDataById(int Id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDataById", new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactionDataByBankAccountId(int baId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataByBankAccountId", new SqlParameter("Id", baId)).ToListAsync();
        }

        public async Task<Transaction> GetTransactionDataById(int Id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataById", new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }
    }
}