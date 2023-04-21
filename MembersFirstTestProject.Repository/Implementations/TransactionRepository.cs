using MembersFirstTestProject.Model.Transaction;
using MembersFirstTestProject.Repository.Interfaces;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MembersFirstTestProject.Repository.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        /// <summary>
        /// Gets A Specific Transaction By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Transaction Model</returns>
        public async Task<TransactionModel?> GetTransactionById(string id)
        {
            using var reader          = new StreamReader(@".\Data\transactions.json");
            var       json            = await reader.ReadToEndAsync();
            var       allTransactions = JsonSerializer.Deserialize<List<TransactionModel>>(json);
            return allTransactions == null ? new TransactionModel() : allTransactions.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Returns A List Of Transactions By A Specified Parameter
        /// </summary>
        /// <param name="searchList"></param>
        /// <returns>List Of Transactions</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TransactionModel>?> SearchTransactions(Dictionary<string, string> searchList)
        {
            var       filteredTransactions = new List<TransactionModel>();

            using var reader               = new StreamReader(@".\Data\transactions.json");
            var       json                 = await reader.ReadToEndAsync();
            var       allTransactions      = JsonSerializer.Deserialize<List<TransactionModel>>(json);

            if (allTransactions == null) return filteredTransactions;
            foreach (var transactionModels in searchList.Select(search => allTransactions.Where(x => search.Key  == search.Value).ToList()))
            {
                filteredTransactions.AddRange(transactionModels);
            }

            return filteredTransactions;
        }

        /// <summary>
        /// A List Of Transactions By Account Number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>A List Of Transactions</returns>
        public async Task<List<TransactionModel>?> GetAllTransactionsByAccountNumber(string accountNumber)
        {
            using var reader          = new StreamReader(@".\Data\transactions.json");
            var       json            = await reader.ReadToEndAsync();
            var       allTransactions = JsonSerializer.Deserialize<List<TransactionModel>>(json);
            return allTransactions == null || !allTransactions.Any()
                ? new List<TransactionModel>()
                : allTransactions.Where(x => x.AccountNumber == accountNumber).ToList();
        }

        /// <summary>
        /// A List Of Transactions By A Specified Date Range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>A List Of Transactions</returns>
        public async Task<List<TransactionModel>?> GetTransactionsByDateRange(DateTime? startDate, DateTime? endDate)
        {
            using var reader          = new StreamReader(@".\Data\transactions.json");
            var       json            = await reader.ReadToEndAsync();
            var       allTransactions = JsonSerializer.Deserialize<List<TransactionModel>>(json);

            if (startDate == null && endDate != null)
            {
                return allTransactions == null || !allTransactions.Any() ? new List<TransactionModel>() :
                    allTransactions.Where(x => x.PostDate <= endDate).OrderBy(x => x.PostDate).ToList();
            }

            if (startDate != null && endDate == null)
            {
                return allTransactions == null || !allTransactions.Any() ? new List<TransactionModel>() :
                    allTransactions.Where(x => x.PostDate >= startDate).OrderBy(x => x.PostDate).ToList();
            }

            return allTransactions == null || !allTransactions.Any() ? new List<TransactionModel>() :
                allTransactions.Where(x => x.PostDate >= startDate && x.PostDate <= endDate).OrderBy(x => x.PostDate).ToList();

        }
    }
}