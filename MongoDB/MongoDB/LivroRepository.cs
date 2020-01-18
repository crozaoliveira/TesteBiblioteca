using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB
{
    public class LivroRepository
    {

        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Livro> _booksCollection;

        public LivroRepository(string connectionString)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("book");
            _booksCollection = _database.GetCollection<Livro>("livro");
        }

        public async Task InsertLivro (Livro livro) 
        {
            await _booksCollection.InsertOneAsync(livro);
        }

        public List<Livro> GetAllLivros()
        {
            return _booksCollection.Find(new BsonDocument()).ToList();
        }

        public List<Livro> GetLivrosByField(string fieldName, string fieldValue)
        {
            var filter = Builders<Livro>.Filter.Eq(fieldName, fieldValue);
            var result = _booksCollection.Find(filter).ToList();

            return result;
        }

        public Livro GetLivrosById(string id)
        {
            var filter = Builders<Livro>.Filter.Eq("_id", id);
            var result = _booksCollection.Find(filter).FirstOrDefault();
            return result;
        }

        public List<Livro> GetLivros(int startingFrom, int count)
        {
            var result = _booksCollection.Find(new BsonDocument())
            .Skip(startingFrom)
            .Limit(count)
            .ToList();

            return result;
        }

        public bool UpdateLivro(ObjectId id, string updateFieldTitle, string updateFieldAutor)
        {
            var filter = Builders<Livro>.Filter.Eq("_id", id);
            var update = Builders<Livro>.Update.Set(updateFieldTitle, updateFieldAutor);

            var result = _booksCollection.UpdateOne(filter, update);

            return result.ModifiedCount != 0;
        }

        public bool DeleteLivroById(ObjectId id)
        {
            var filter = Builders<Livro>.Filter.Eq("_id", id);
            var result = _booksCollection.DeleteOne(filter);
            return result.DeletedCount != 0;
        }

    }
}
