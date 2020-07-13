using ExpenseApp.Business.Contracts;
using ExpenseApp.Models;
using ExpenseApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Business
{
    public class ExpenseManager : IExpenseManager
    {
        readonly IExpenseRepository _expenseRepository;
        public ExpenseManager(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<bool> AddExpenseAsync(Expense expense)
        {
            return await _expenseRepository.AddExpenseAsync(expense);
        }

        public Task<bool> DeleteExpense(int expenseId)
        {
            throw new NotImplementedException();
        }

        public async Task<Expense> GetExpenseByIdAsync(int expenseId)
        {
            return await _expenseRepository.GetExpenseByIdAsync(expenseId);
        }

        public async Task<List<Expense>> GetExpensesAsync(int userId)
        {
            return await _expenseRepository.GetExpensesAsync(userId);
        }

        public Task<List<Expense>> GetExpensesAsync(int userId, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> UpdateExpenseAsync(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
