using ExpenseApp.Business.Contracts;
using ExpenseApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExpenseApp.Web
{
    //[Authorize]
    [RoutePrefix("api/expense")]
    public class ExpenseController : ApiController
    {
        private readonly IExpenseManager _expenseManager;
        public ExpenseController()
        {

        }
        public ExpenseController(IExpenseManager expenseManager)
        {
            _expenseManager = expenseManager;
        }


        // GET: api/Expense
        [HttpGet]
        [Route("expenses")]
        public async Task<List<Expense>> GetExpenses(int userId)
        
        {
            return await _expenseManager.GetExpensesAsync(userId);
        }

        // GET: api/Expense/5
        [HttpGet]
        public async Task<Expense> Get(int expenseId)
        {
            return await _expenseManager.GetExpenseByIdAsync(expenseId);
        }

        // POST: api/Expense
        [HttpPost]
        public async Task<bool> Post([FromBody]Expense expense)
        {
            return await _expenseManager.AddExpenseAsync(expense);
        }

        // PUT: api/Expense/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Expense/5
        public void Delete(int id)
        {
        }
    }
}
