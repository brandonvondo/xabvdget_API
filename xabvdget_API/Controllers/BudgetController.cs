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
    [RoutePrefix("api/Budgets")]
    public class BudgetsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        //Budget Data
        [HttpGet, Route("GetBudgetById")]

        public async Task<Budget> GetBudgetById(int Id)
        {
            return await db.GetBudgetDataById(Id);
        }

        [HttpGet, Route("GetBudgetById/json")]
        public async Task<IHttpActionResult> GetBudgetByIdJSON(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetDataById(Id));
            return Ok(json);
        }

        [HttpGet, Route("GetBudgetByHouseholdId")]
        public async Task<List<Budget>> GetBudgetByHouseholdId(int hhId)
        {
            return await db.GetBudgetDataByHouseholdId(hhId);
        }

        [HttpGet, Route("GetBudgetByHouseholdId/json")]
        public async Task<IHttpActionResult> GetBudgetByHouseholdIdJSON(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetDataByHouseholdId(hhId));
            return Ok(json);
        }
    }
}