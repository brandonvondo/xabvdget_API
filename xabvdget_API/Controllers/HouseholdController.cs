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
    [RoutePrefix("api/Households")]
    public class HouseholdsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();


        //Households
        public async Task<Household> GetHouseholdById(int hhId)
        {
            return await db.GetHouseholdDataById(hhId);
        }

        [Route("GetHouseHoldById/json")]
        public async Task<IHttpActionResult> GetHouseholdByIdJSON(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetHouseholdDataById(hhId));
            return Ok(json);
        }

    }
}