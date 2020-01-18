using MongoDB;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class LoanController : ApiController
    {

        public static string connection = "mongodb://localhost:27017";
        LoanRepository Loan = null;
        // GET api/<controller>

        LoanController()
        {
            Loan = new LoanRepository(connection);
        }

        public List<Loan> Get()
        {
            return Loan.GetAllLoan();
        }

        // GET api/<controller>/5
        public Loan Get(string id)
        {
            return Loan.GetLoanById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Loan loan)
        {
            var r = Loan.InsertLoan(loan);
        }

        // PUT api/<controller>/5
        /* public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE api/<controller>/5
        public void Delete(ObjectId id)
        {
            var r = Loan.DeleteLoanById(id);
        }
    }
}