using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xabvdget_API.Models
{
    public class Household
    {
        public int Id { get; set; }

        // Properties
        public string HouseholdName { get; set; }
        public string Greeting { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }


    }

    public class BankAccount
    {
        public int Id { get; set; }

        // Parents
        public int HouseholdId { get; set; }

        public string AccountName { get; set; } //System Name
        public DateTime Created { get; set; }
        public string CreatedString { get; internal set; }
        public decimal StartingBalance { get; internal set; }
        public decimal CurrentBalance { get; set; }
        public decimal WarningBalance { get; set; }
        public bool IsDeleted { get; set; }
        public AccountType AccountType { get; set; }
    }

    public enum AccountType
    {
        Checking,
        Savings
    }

    public class Transaction
    {
        public int Id { get; set; }

        public int AccountId { get; set; }
        public int? BudgetItemId { get; set; }

        // Properties
        public TransactionType TransactionType { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; } 
        public bool IsDeleted { get; set; }

    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }

    public class Budget
    {
        public int Id { get; set; }

        // Parents
        public int HouseHoldId { get; set; }
        public string UserId { get; set; }

        // Actual Properties
        public DateTime Created { get; set; }
        public string BudgetName { get; set; }

    }

    public class BudgetItem
    {
        public int Id { get; set; }

        // Parents
        public int BudgetId { get; set; }

        // Actual Properties
        public DateTime Created { get; set; }
        public string ItemName { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public bool IsDeleted { get; set; }


    }



}