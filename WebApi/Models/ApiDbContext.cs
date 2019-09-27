using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi.Models
{
    //[RoutePrefix("")]
    public class ApiDbContext : DbContext 
    {
        public ApiDbContext()
        : base("DefaultConnection")
        { }

        public static ApiDbContext Create()
        {
            return new ApiDbContext();

        }

        public DbSet<Household> Households { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public async Task<List<Household>> GetAllHouseholdRecords()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdRecords").ToListAsync();
        }

        public async Task<Household> GetHouseholdData(int houseId)
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdRecords @houseId",
                new SqlParameter("houseId", houseId)).FirstOrDefaultAsync();
        }

        public async Task<List<BankAccount>> GetAllBankAccounts(int houseId)
        {
            return await Database.SqlQuery<BankAccount>("GetAllBankAccounts @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }

        public async Task<BankAccount> GetBankAccountData(int bankId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountData @bankId",
                new SqlParameter("bankId", bankId)).FirstOrDefaultAsync();
        }
        public async Task<List<Budget>> GetAllBudgets(int houseId)
        {
            return await Database.SqlQuery<Budget>("GetAllBudgets @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }
        public async Task<Budget> GetBudgetData(int houseId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetData @houseId",
                new SqlParameter("houseId", houseId)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetItem>> GetAllBudgetItems(int budgetId)
        {
            return await Database.SqlQuery<BudgetItem>("GetAllBudgetItems @budgetId",
                new SqlParameter("budgetId", budgetId)).ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemData(int itemId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemData @budgetItemId",
                new SqlParameter("budgetItemId", itemId)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetAllTransactions(int bankId)
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactions @bankId",
                new SqlParameter("bankId", bankId)).ToListAsync();
        }

        public async Task<Transaction> GetTransactionData(int transId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionData @transId",
                new SqlParameter("transId", transId)).FirstOrDefaultAsync();
        }

        public async Task<int> AddBudget (int houseId, string name, double target, double actual)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @houseId, @name, @target, @actual",
                new SqlParameter("houseId", houseId),
                new SqlParameter ("name", name),
                new SqlParameter("target", target),
                new SqlParameter("actual", actual));

        }

        public async Task<int> AddBankAccount(int houseId, string ownerId, int accTypeId, double startBal, 
                                              double currentBal,  double lowBal, string name, string description,
                                               string address, string city, string state, int zip, int phone)
        {
            return await Database.ExecuteSqlCommandAsync("AddBankAccount @houseId, @ownerId, @accType, @startBal, @currentBal, @lowBal, @name, @description, @address, @city, @state, @zip, @phone ",
                    new SqlParameter ("houseId", houseId),
                    new SqlParameter("ownerId", ownerId),
                    new SqlParameter("accType", accTypeId),
                    new SqlParameter("startBal", startBal),
                    new SqlParameter("currentBal", currentBal),
                    new SqlParameter("lowBal", lowBal),
                    new SqlParameter("description", description),
                    new SqlParameter("address", address),
                    new SqlParameter("city", city),
                    new SqlParameter("state", state),
                    new SqlParameter("zip", zip),
                    new SqlParameter("phone", phone)
                    );
        }

        public async Task<int> AddTransAction(int bankId, int transId, int budgetItemId, string ownerId, double amount, string memo)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @bankId, @transId, @budgetItemId, @ownerId, @amount, @memo",
                     new SqlParameter("bankId", bankId),
                     new SqlParameter("transId", transId),
                     new SqlParameter("budgetItemId", budgetItemId),
                     new SqlParameter("ownerId", ownerId),
                     new SqlParameter("amount", amount),
                     new SqlParameter("memo", memo)
                     );

        }


    }

}