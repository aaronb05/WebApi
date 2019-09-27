using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using System.Web.Util;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/TransactionServices")]
    public class TransactionServicesController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        /// <summary>
        /// Get all transactions for an account
        /// </summary>
        /// <param name="bankId"></param>
        /// <returns></returns>
        [Route("GetTransActions")]
        public async Task<List<Transaction>> GetAllTransactions(int bankId)
        {
            return await db.GetAllTransactions(bankId);

        }
        /// <summary>
        /// Get data for a specific transaction
        /// </summary>
        /// <param name="transId"></param>
        /// <returns></returns>
        [Route("GetTransactionData/json")]
        public async Task<IHttpActionResult> GetTransactionData(int transId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetTransactionData(transId);
            return Json(data, serializerSettings);

        }

        public async Task<IHttpActionResult> AddTransaction(int bankId, int transId, int budgetItemId, string ownerId, 
                                                            double amount, string memo)
        {
            return Ok(JsonConvert.SerializeObject(await AddTransaction(bankId, transId, budgetItemId,
                                                                        ownerId, amount,
                                                                        memo)));

        }

    }
}