using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<Transaction> GetTransactionById(int Id)
        {
            return await db.GetTransactionDataById(Id);
        }

        [Route("GetTransactionById/json")]
        public async Task<IHttpActionResult> GetTransactionByIdJSON(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactionDataById(Id));
            return Ok(json);
        }

        public async Task<List<Transaction>> GetTransactionByBankAccountId(int baId)
        {
            return await db.GetTransactionDataByBankAccountId(baId);
        }

        [Route("GetTransactionByBankAccountId/json")]
        public async Task<IHttpActionResult> GetTransactionByBankAccountIdJSON(int baId)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactionDataByBankAccountId(baId));
            return Ok(json);
        }

    }
}