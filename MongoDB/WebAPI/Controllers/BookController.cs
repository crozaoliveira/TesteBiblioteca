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
    public class BookController : ApiController
    {

        public static string connection = "mongodb://localhost:27017";
        LivroRepository Livro = null;
        // GET api/<controller>

        BookController()
        {
            Livro = new LivroRepository(connection);
        }

        public List<Livro> Get()
        {
            return Livro.GetAllLivros();
        }

        // GET api/<controller>/5
        public Livro Get(string id)
        {
            return Livro.GetLivrosById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Livro livro)
        {
            var r = Livro.InsertLivro(livro);
        }

        // PUT api/<controller>/5
        /* public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE api/<controller>/5
        public void Delete(ObjectId id)
        {
            var r = Livro.DeleteLivroById(id);
        }

        // UPDATE api/<controller>/5
        public void Update(ObjectId id, string updateFieldTitle, string updateFieldAutor)
        {
            var r = Livro.UpdateLivro(id, updateFieldTitle, updateFieldAutor);  
        }
    }
}