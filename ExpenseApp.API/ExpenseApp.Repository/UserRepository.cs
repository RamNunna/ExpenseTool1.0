using Dapper;
using ExpenseApp.Entites;
using ExpenseApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApp.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUserByEmailIdAsync(string emailId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@EmailId", emailId);
                    return con.Query<User>("Usp_GetUserByEmailId", parameters, sqltans, true,null, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<User> GetUserByIdAsync(int _userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction sqltans = con.BeginTransaction();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@EmailId", user.EmailId);
                    parameters.Add("@MobileNo", user.MobileNo);
                    parameters.Add("@Password", user.Password);
                    var result = await con.ExecuteAsync("Usp_Register", parameters, sqltans, null, System.Data.CommandType.StoredProcedure);
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
    }
}
