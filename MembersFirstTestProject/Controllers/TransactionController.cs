using System.Net;
using MembersFirstTestProject.Orchestrator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MembersFirstTestProject.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionOrchestration _transactionOrchestration;

        public TransactionController(ITransactionOrchestration transactionOrchestration)
        {
            _transactionOrchestration = transactionOrchestration;
        }

        /// <summary>
        /// Gets A Specific Transaction By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Transaction Model</returns>
        [HttpGet]
        [Route("GetTransactionById")]
        public async Task<IActionResult> GetTransactionById(string id)
        {
            var data = await _transactionOrchestration.GetTransactionById(id);
            var code = data != null
                ? Convert.ToInt32(HttpStatusCode.OK)
                : Convert.ToInt32(HttpStatusCode.InternalServerError);

            return StatusCode(code, data);
        }

        [HttpPost]
        [Route("SearchTransactions")]
        public async Task<IActionResult> SearchTransactions(Dictionary<string, string> searchList)
        {
            var data = await _transactionOrchestration.SearchTransactions(searchList);
            var code = data != null
                ? Convert.ToInt32(HttpStatusCode.OK)
                : Convert.ToInt32(HttpStatusCode.InternalServerError);

            return StatusCode(code, data);
        }

        /// <summary>
        /// Gets A List Of Transactions By A Specified Account Number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>List of Transactions</returns>
        [HttpGet]
        [Route("GetAllTransactionsByAccountNumber")]
        public async Task<IActionResult> GetAllTransactionsByAccountNumber(string accountNumber)
        {
            var data = await _transactionOrchestration.GetAllTransactionsByAccountNumber(accountNumber);
            var code = data != null
                ? Convert.ToInt32(HttpStatusCode.OK)
                : Convert.ToInt32(HttpStatusCode.InternalServerError);

            return StatusCode(code, data);
        }

        /// <summary>
        /// Gets A List Of Transactions By A Specified Date Range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>List of Transactions</returns>
        [HttpGet]
        [Route("GetTransactionsByDateRange")]
        public async Task<IActionResult> GetTransactionsByDateRange(DateTime? startDate, DateTime? endDate)
        {
            var data = await _transactionOrchestration.GetTransactionsByDatRange(startDate, endDate);
            var code = data != null
                ? Convert.ToInt32(HttpStatusCode.OK)
                : Convert.ToInt32(HttpStatusCode.InternalServerError);

            return StatusCode(code, data);
        }
    }
}
