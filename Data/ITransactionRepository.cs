using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiConversor.Models
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAll();
        Transaction Get(int id);
        bool Add(Transaction transaction);
        void Remove(int id);
        bool Update(Transaction transaction);
    }
}
