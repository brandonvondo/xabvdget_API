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

        [HttpGet, Route("GetBudgetItemById")]
        public async Task<BudgetItem> GetBudgetItemById(int Id)
        {
            return await db.GetBudgetItemDataById(Id);
        }

        [HttpGet, Route("GetBudgetItemById/json")]
        public async Task<IHttpActionResult> GetBudgetItemByIdJSON(int Id)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetItemDataById(Id));
            return Ok(json);
        }

        [HttpGet, Route("GetBudgetItemByBudgetId")]
        public async Task<List<BudgetItem>> GetBudgetItemByBudgetId(int bId)
        {
            return await db.GetBudgetItemDataByBudgetId(bId);
        }

        [HttpGet, Route("GetBudgetItemByBudgetId/json")]
        public async Task<IHttpActionResult> GetBudgetItemByBudgetJSON(int bId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetItemDataByBudgetId(bId));
            return Ok(json);
        }
    }
}