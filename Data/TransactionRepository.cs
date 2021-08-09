using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiConversor.Models;

namespace WebApiConversor.Data
{
    public class TransactionRepository:ITransactionRepository
    {
        private List<Transaction> Transactions = new List<Transaction>();
        private int _nextId = 1;
        public TransactionRepository()
        {
            Add(new Transaction { idUser = 1});
        }
        public IEnumerable<Transaction> GetAll()
        {
            return Transactions;
        }
        public Transaction Get(int id)
        {
            return Transactions.Find(s => s.id == id);
        }
        public bool Add(Transaction Transaction)
        {
            bool addResult = false;
            if (Transaction == null)
            {
                return addResult;
            }
            int index = Transactions.FindIndex(s => s.id == Transaction.id);
            if (index == -1)
            {
                Transactions.Add(Transaction);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        public void Remove(int id)
        {
            Transactions.RemoveAll(s => s.id == id);
        }
        public bool Update(Transaction Transaction)
        {
            if (Transaction == null)
            {
                throw new ArgumentNullException("Transaction");
            }
            int index = Transactions.FindIndex(s => s.id == Transaction.id);
            if (index == -1)
            {
                return false;
            }
            Transactions.RemoveAt(index);
            Transactions.Add(Transaction);
            return true;
        }
    }
}