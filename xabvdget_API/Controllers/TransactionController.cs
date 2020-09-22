using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using xabvdget_API.Models;

namespace xabvdget_API.Controllers
{
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        //Transactions
        /// <summary>
        /// Get a transaction by its own Id
        /// </summary>
        /// <param name="Id">The transactions unique ID</param>
        /// <returns></returns>
        [HttpGet, Route("GetTransactionById")]
        public async Task<Transaction> GetTransactionById(int Id)
        {
            return await db.GetTransactionDataById(Id);
        }

        /// <summary>
        /// Get a transaction by its own Id (Returns JSON)
        /// </summary>
        /// <param name="Id">The transactions unique ID</param>
        /// <returns></returns>
        [HttpGet, Route("GetTransactionById/json")]
        public async Task<IHttpActionResult> GetTransactionByIdJSON(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactionDataById(Id));
            return Ok(json);
        }

        /// <summary>
        /// Get all transaction from a bank account
        /// </summary>
        /// <param name="baId">The bank account to list the transactions of</param>
        /// <returns></returns>
        [HttpGet, Route("GetTransactionByBankAccountId")]
        public async Task<List<Transaction>> GetTransactionByBankAccountId(int baId)
        {
            return await db.GetTransactionDataByBankAccountId(baId);
        }

        /// <summary>
        /// Get all transaction from a bank account (Returns JSON)
        /// </summary>
        /// <param name="baId">The bank account to list the transactions of</param>
        /// <returns></returns>
        [HttpGet, Route("GetTransactionByBankAccountId/json")]
        public async Task<IHttpActionResult> GetTransactionByBankAccountIdJSON(int baId)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactionDataByBankAccountId(baId));
            return Ok(json);
        }


        /// <summary>
        /// This method creates a new transaction
        /// </summary>
        /// <param name="accountId">The bank account to pull from</param>
        /// <param name="budgetItemId">The budget item that it is under</param>
        /// <param name="ownerId">Who made the transaction</param>
        /// <param name="transactionType">Deposit, withdrawal, or transfer</param>
        /// <param name="amount">The amount of the transaction</param>
        /// <param name="memo">Notes about it e.g. mcdonalds</param>
        /// <param name="isDeleted">Bool for soft delete</param>
        /// <returns>Success or failure</returns>
        [HttpPost, Route("CreateTransaction")]
        public IHttpActionResult CreateTransaction(int accountId, int budgetItemId, string ownerId, int transactionType, decimal amount, string memo, bool isDeleted)
        {
            return Ok(db.CreateTransaction(accountId, budgetItemId, ownerId, transactionType, amount, memo, isDeleted));
        }


        /// <summary>
        /// Edit an existing transaction
        /// </summary>
        /// <param name="id">The Transaction to change</param>
        /// <param name="accountId">The bank account to pull from</param>
        /// <param name="budgetItemId">The budget item that it is under</param>
        /// <param name="ownerId">Who made the transaction</param>
        /// <param name="transactionType">Deposit, withdrawal, or transfer</param>
        /// <param name="amount">The amount of the transaction</param>
        /// <param name="memo">Notes about it e.g. mcdonalds</param>
        /// <param name="isDeleted">Bool for soft delete</param>
        /// <returns>Success or failure</returns>
        [HttpPatch, Route("EditTransaction")]
        public IHttpActionResult EditTransaction(int id, int accountId, int budgetItemId, string ownerId, int transactionType, decimal amount, string memo, bool isDeleted)
        {
            return Ok(db.EditTransaction(id, accountId, budgetItemId, ownerId, transactionType, amount, memo, isDeleted));
        }

        /// <summary>
        /// Delete an existing transaction
        /// </summary>
        /// <param name="id">The ID of the transaction to remove</param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteTransaction")]
        public IHttpActionResult DeleteTransaction(int id)
        {
            return Ok(db.DeleteTransaction(id));
        }

    }
}