using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.Models;


namespace WebApi.Controllers
{
    [RoutePrefix("api/BudgetServices")]
    
    public class BudgetServicesController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Get all budgets for a specific house
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<List<Budget>> GetAllBudgets(int houseId)
        {
            return await db.GetAllBudgets(houseId);
        }
        /// <summary>
        /// Get data for a specific Budget
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        [Route("GetBudgetData/json")]
        public async Task<IHttpActionResult> GetBudgetData(int budgetId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetData(budgetId);
            return Json(data, serializerSettings);

        }

        /// <summary>
        /// Get all budgets items under a sepcific Budget
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        [Route("GetBudgetItems")]
        public async Task<List<Budget>> GetAllBudgetItems(int budgetId)
        {
            return await db.GetAllBudgets(budgetId);
        }

        /// <summary>
        /// Get the data from 1 specific Budget Item 
        /// </summary>
        /// <param name="budgetItemId"></param>
        /// <returns></returns>
        [Route("GetBudgetItemData/json")]
        public async Task<IHttpActionResult> GetBudgetItemData(int budgetItemId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBudgetItemData(budgetItemId);
            return Json(data, serializerSettings);

        }

        public async Task<IHttpActionResult> AddBudget(int houseId, string name, double target, double actual)
        {

            return Ok(JsonConvert.SerializeObject(await AddBudget( houseId, name, target, actual)));
        }
    }
}