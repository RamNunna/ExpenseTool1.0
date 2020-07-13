using ExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Business.Contracts
{
    public interface IExpenseManager
    {
        Task<List<Expense>> GetExpensesAsync(int userId);
        Task<List<Expense>> GetExpensesAsync(int userId, DateTime fromDate, DateTime toDate);
        Task<Expense> GetExpenseByIdAsync(int expenseId);
        Task<bool> AddExpenseAsync(Expense expense);
        Task<Expense> UpdateExpenseAsync(Expense expense);
        Task<bool> DeleteExpense(int expenseId);
    }
}
