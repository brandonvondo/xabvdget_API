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
            return await Database.SqlQuery<Household>("GetHouseholdDataById @id", new SqlParameter("Id", hhId)).FirstOrDefaultAsync();
        }

        public async Task<List<Budget>> GetBudgetDataByHouseholdId(int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataByHouseholdId @houseHoldId", new SqlParameter("Id", hhId)).ToListAsync();
        }

        public async Task<Budget> GetBudgetDataById(int Id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataById @id", new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetItem>> GetBudgetItemDataByBudgetId(int bId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDataByBudgetId @budgetId", new SqlParameter("Id", bId)).ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDataById(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDataById @id", new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        public async Task<List<BankAccount>> GetBankAccountDataByHouseholdId(int hhId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDataByHouseholdId  @houseHoldId", new SqlParameter("Id", hhId)).ToListAsync();
        }

        public async Task<BankAccount> GetBankAccountDataById(int Id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDataById @id", new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactionDataByBankAccountId(int baId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataByBankAccountId @bankAccountId", new SqlParameter("Id", baId)).ToListAsync();
        }

        public async Task<Transaction> GetTransactionDataById(int Id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataById @id", new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        public int CreateTransaction(int accountId, int budgetItemId, string ownerId, int transactionType, decimal amount, string memo, bool isDeleted)
        {
            return Database.ExecuteSqlCommand("CreateTransaction @accountId, @budgetItemId, @ownerId, @transactionType, @amount, @memo, @isDeleted",
                new SqlParameter("accountId", accountId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownderId", ownerId),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo),
                new SqlParameter("isDeleted", isDeleted)
                );
        }

        public int EditTransaction(int id, int accountId, int budgetItemId, string ownerId, int transactionType, decimal amount, string memo, bool isDeleted)
        {
            return Database.ExecuteSqlCommand("EditTransaction @id, @accountId, @budgetItemId, @ownerId, @transactionType, @amount, @memo, @isDeleted",
                new SqlParameter("id", id),
                new SqlParameter("accountId", accountId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownderId", ownerId),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo),
                new SqlParameter("isDeleted", isDeleted)
                );
        }

        public int DeleteTransaction(int id)
        {
            return Database.ExecuteSqlCommand("DeleteTransaction @id",
                new SqlParameter("id", id));
        }
    }
}