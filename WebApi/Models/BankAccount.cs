using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Enum;
using WebApi.Enumerations;

namespace WebApi.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public int HouseholdId { get; set; }
        public AccountTypes AccountTypeId { get; set; }
        public double StartingBalance { get; set; }
        public double CurrentBalance { get; set; }
        public double LowBalance { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
    }
}