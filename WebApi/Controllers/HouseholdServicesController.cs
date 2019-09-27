using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/HouseholdServices")]
    public class HouseholdServicesController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Get all Households
        /// </summary>
        /// <returns></returns>
        [Route("GetHouseholds")]
        public async Task<List<Household>> GetHouseholds()
        {
            return await db.GetAllHouseholdRecords();
        }

        /// <summary>
        /// Get data for a specific Household
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        [Route("GetHouseholdData/json")]
        public async Task<IHttpActionResult> GetHouseholdsAsJson(int houseId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetHouseholdData(houseId);
            return Json(data, serializerSettings);
        }

        

    }
}