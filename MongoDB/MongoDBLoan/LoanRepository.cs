using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB
{
    public class LoanRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Loan> _loanCollection;

        public LoanRepository(string connectionString)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("book");
            _loanCollection = _database.GetCollection<Loan>("loan");
        }

        public async Task InsertLoan(Loan loan)
        {
            await _loanCollection.InsertOneAsync(loan);
        }

        public List<Loan> GetAllLoan()
        {
            return _loanCollection.Find(new BsonDocument()).ToList();
        }

        public List<Loan> GetLoanByField(string fieldName, string fieldValue)
        {
            var filter = Builders<Loan>.Filter.Eq(fieldName, fieldValue);
            var result = _loanCollection.Find(filter).ToList();

            return result;
        }

        public Loan GetLoanById(string id)
        {
            var filter = Builders<Loan>.Filter.Eq("_id", id);
            var result = _loanCollection.Find(filter).FirstOrDefault();
            return result;
        }

        public List<Loan> GetLoan(int startingFrom, int count)
        {
            var result = _loanCollection.Find(new BsonDocument())
            .Skip(startingFrom)
            .Limit(count)
            .ToList();

            return result;
        }

        public bool DeleteLoanById(ObjectId id)
        {
            var filter = Builders<Loan>.Filter.Eq("_id", id);
            var result = _loanCollection.DeleteOne(filter);
            return result.DeletedCount != 0;
        }
    }
}
