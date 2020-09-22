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
    [RoutePrefix("api/BankAccounts")]
    public class BankAccountsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        //Bank Account

        [HttpGet, Route("GetBankAccountById")]
        public async Task<BankAccount> GetBankAccountById(int Id)
        {
            return await db.GetBankAccountDataById(Id);
        }

        [HttpGet, Route("GetBankAccountById/json")]
        public async Task<IHttpActionResult> GetBankAccountByIdJSON(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetBankAccountDataById(Id));
            return Ok(json);
        }

        [HttpGet, Route("GetBankAccountByHouseholdId")]
        public async Task<List<BankAccount>> GetBankAccountByHouseholdId(int hhId)
        {
            return await db.GetBankAccountDataByHouseholdId(hhId);
        }

        [HttpGet, Route("GetBankAccountByHouseholdId/json")]
        public async Task<IHttpActionResult> GetBankAccountByHouseholdIdJSON(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBankAccountDataByHouseholdId(hhId));
            return Ok(json);
        }

    }
}