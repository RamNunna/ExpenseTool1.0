using Dapper;
using ExpenseApp.Models;
using ExpenseApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        public async Task<bool> AddExpenseAsync(Expense expense)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ExpenseId", expense.ExpenseId);
                    parameters.Add("@UserId", expense.UserId);
                    parameters.Add("@ExpenseName", expense.ExpenseName);
                    parameters.Add("@Amount", expense.Amount);
                    parameters.Add("@Date", expense.Date);
                    var result = await con.ExecuteAsync("Usp_ExpenseUpsert", parameters, sqltans, null, System.Data.CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        sqltans.Commit();
                    }
                    else
                    {
                        sqltans.Rollback();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> DeleteExpense(int expenseId)
        {
            throw new NotImplementedException();
        }

        public  async Task<Expense> GetExpenseByIdAsync(int expenseId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ExpenseId", expenseId);
                    return con.Query<Expense>("Usp_GetExpenseById", parameters, sqltans, true, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Expense>> GetExpensesAsync(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@UserId", userId);
                    return con.Query<Expense>("Usp_GetExpenseByUserId", parameters, sqltans, true, null, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
