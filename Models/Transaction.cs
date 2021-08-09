using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConversor.Models
{
    public class Transaction
    {        
        public int id { get; set; }
        public int idUser { get; set; }
        public int coin { get; set; }
        public decimal value { get; set; }
        public int destinyCoin { get; set; }
        public int destinyValue { get; set; }
        public decimal tax { get; set; }
        public DateTime date { get; set; }

    }
}