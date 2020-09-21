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
    [RoutePrefix("api/BudgetItems")]
    public class BudgetItemsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();


        //Budget Item

        public async Task<BudgetItem> GetBudgetItemById(int Id)
        {
            return await db.GetBudgetItemDataById(Id);
        }

        [Route("GetBudgetItemById/json")]
        public async Task<IHttpActionResult> GetBugetItemByIdJSON(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetItemDataById(Id));
            return Ok(json);
        }

        public async Task<List<BudgetItem>> GetBudgetItemByBudgetId(int bId)
        {
            return await db.GetBudgetItemDataByBudgetId(bId);
        }

        [Route("GetBudgetItemByBudgetId/json")]
        public async Task<IHttpActionResult> GetBugetItemByBudgetJSON(int bId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetItemDataByBudgetId(bId));
            return Ok(json);
        }
    }
}