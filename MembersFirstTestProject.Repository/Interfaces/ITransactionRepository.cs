using MembersFirstTestProject.Model.Transaction;

namespace MembersFirstTestProject.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        Task<TransactionModel?>       GetTransactionById(string id);
        Task<List<TransactionModel>?> SearchTransactions(Dictionary<string, string> searchList);
        Task<List<TransactionModel>?> GetAllTransactionsByAccountNumber(string accountNumber);
        Task<List<TransactionModel>?> GetTransactionsByDateRange(DateTime?     startDate, DateTime? endDate);
    }
}
