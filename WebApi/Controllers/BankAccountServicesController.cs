using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.Models;
//using System.Web.Mvc;

namespace WebApi.Controllers
{
    [RoutePrefix("api/BankAccountServices")]
    public class BankAccountServicesController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Get all bank accounts for a specific Household
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        [Route("GetBankAccounts")]
        public async Task<List<BankAccount>> GetAllBankAccounts(int houseId)
        {
            return await db.GetAllBankAccounts(houseId);

        }

        /// <summary>
        /// Get data for a specific Bank Account 
        /// </summary>
        /// <param name="bankId"></param>
        /// <returns></returns>
        [Route("GetBankData/json")]
        public async Task<IHttpActionResult> GetBankAccountData(int bankId)
        {
            var serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var data = await db.GetBankAccountData(bankId);
            return Json(data, serializerSettings);
        }

        public async Task<IHttpActionResult> AddBankAccount(int houseId, string ownerId, int accTypeId, double startBal,
                                              double currentBal, double lowBal, string name, string description,
                                               string address, string city, string state, int zip, int phone)
        {
            return Ok(JsonConvert.SerializeObject(await AddBankAccount(houseId, ownerId, accTypeId, startBal,
                                                                       currentBal, lowBal, name, description, address,
                                                                       city, state, zip, phone)));
        }

        
    }
}