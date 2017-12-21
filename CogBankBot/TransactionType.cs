using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CogBankBot
{
    [Serializable]
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public static List<string> CreateTransactionsList()
        {
            List<string> transactionList = new List<string>();

            TransactionType A = new TransactionType();
            TransactionType B = new TransactionType();

            A.Id = 0;
            A.Name = "Balance Inquiry";
            A.Description = "Transaction for Balance Inquiry";

            B.Id = 1;
            B.Name = "Funds Transfer";
            B.Description = "Transaction for Funds Transfer";

            transactionList.Add(A.Name);
            transactionList.Add(B.Name);

            return transactionList;
        }

    }
}