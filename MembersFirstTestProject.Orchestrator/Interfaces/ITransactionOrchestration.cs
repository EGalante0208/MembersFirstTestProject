using MembersFirstTestProject.Model.Transaction;

namespace MembersFirstTestProject.Orchestrator.Interfaces
{
    public interface ITransactionOrchestration
    {
        Task<TransactionModel?>       GetTransactionById(string id);
        Task<List<TransactionModel>?> SearchTransactions(Dictionary<string, string> searchList);
        Task<List<TransactionModel>?> GetAllTransactionsByAccountNumber(string accountNumber);
        Task<List<TransactionModel>?> GetTransactionsByDatRange(DateTime?      startDate, DateTime? endDate);
    }
}
