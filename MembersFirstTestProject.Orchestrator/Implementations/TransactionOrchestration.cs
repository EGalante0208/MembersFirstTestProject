using MembersFirstTestProject.Model.Transaction;
using MembersFirstTestProject.Orchestrator.Interfaces;
using MembersFirstTestProject.Repository.Interfaces;

namespace MembersFirstTestProject.Orchestrator.Implementations
{
    /// <summary>
    /// The Orchestration is used as a middle layer for the Controller and the Repository layers. This can be served to connect with other API Services
    /// or send messages across onto service bus queues as an example.
    ///
    /// Custom logic may also be done here as well.
    /// </summary>
    public class TransactionOrchestration : ITransactionOrchestration
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionOrchestration(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        /// <summary>
        /// Get Transaction By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Single Transaction Model</returns>
        public async Task<TransactionModel?> GetTransactionById(string id)
        {
            try
            {
                return await _transactionRepository.GetTransactionById(id);
            }
            catch (Exception)
            {
                // **** In a production environment, there would be logging here. Not implemented for simplicity. ****
                return null;
            }
        }

        /// <summary>
        /// Search Transactions By Any Parameter
        /// </summary>
        /// <param name="searchList"></param>
        /// <returns>A List of Transaction Models</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TransactionModel>?> SearchTransactions(Dictionary<string, string> searchList)
        {
            try
            {
                return await _transactionRepository.SearchTransactions(searchList);
            }
            catch (Exception)
            {
                // **** In a production environment, there would be logging here. Not implemented for simplicity. ****
                return null;
            }
        }

        /// <summary>
        /// Get A List Of Transactions By Account Number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>List Of Transaction Models</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TransactionModel>?> GetAllTransactionsByAccountNumber(string accountNumber)
        {
            try
            {
                return await _transactionRepository.GetAllTransactionsByAccountNumber(accountNumber);
            }
            catch (Exception)
            {
                // **** In a production environment, there would be logging here. Not implemented for simplicity. ****
                return null;
            }
        }

        /// <summary>
        /// Gets A List Of Transactions By Date Range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>A List Of Transaction Models</returns>
        public async Task<List<TransactionModel>?> GetTransactionsByDatRange(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                return await _transactionRepository.GetTransactionsByDateRange(startDate, endDate);
            }
            catch (Exception)
            {
                // **** In a production environment, there would be logging here. Not implemented for simplicity. ****
                return null;
            }
        }
    }
}
