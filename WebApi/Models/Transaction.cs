using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BankAccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public int? BudgetItemId { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Memo { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}