using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiConversor.Data;
using WebApiConversor.Models;

namespace WebApiConversor.Controllers
{
    public class TransactionController : ApiController
    {
        static readonly ITransactionRepository transactionRepository = new TransactionRepository();

        [HttpGet]
        public HttpResponseMessage GetAllTransactions()
        {
            List<Transaction> listaTransactions = transactionRepository.GetAll().ToList();
            return Request.CreateResponse<List<Transaction>>(HttpStatusCode.OK, listaTransactions);
        }

        public HttpResponseMessage GetTransaction(int id)
        {
            Transaction Transaction = transactionRepository.Get(id);
            if (Transaction == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Transaction não localizado para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Transaction>(HttpStatusCode.OK, Transaction);
            }
        }
        //public IEnumerable<Transaction> GetTransactionsPorGenero(string genero)
        //{
        //    return transactionRepository.GetAll().Where(
        //        e => string.Equals(e.genero, genero, StringComparison.OrdinalIgnoreCase));
        //}
        //public IEnumerable<Transaction> GetTransactionsPorIdade(int idade)
        //{
        //    return transactionRepository.GetAll().Where(
        //        e => string.Equals(e.idade.ToString(), idade.ToString(), StringComparison.OrdinalIgnoreCase));
        //}

        public HttpResponseMessage PostTransaction(Transaction Transaction)
        {
            bool result = transactionRepository.Add(Transaction);
            if (result)
            {
                var response = Request.CreateResponse<Transaction>(HttpStatusCode.Created, Transaction);
                string uri = Url.Link("DefaultApi", new { id = Transaction.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Transaction não foi incluído com sucesso");
            }
        }

        public HttpResponseMessage PutTransaction(int id, Transaction Transaction)
        {
            Transaction.id = id;
            if (!transactionRepository.Update(Transaction))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
 "Não foi possível atualizar o Transaction para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        public HttpResponseMessage DeleteTransaction(int id)
        {
            transactionRepository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
