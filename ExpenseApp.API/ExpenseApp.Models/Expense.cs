using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string UserId { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime Date { get; set; }
    }
}
