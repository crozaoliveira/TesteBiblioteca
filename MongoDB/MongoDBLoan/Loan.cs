using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB
{
    public class Loan
    {

        [BsonElement("user")]
        public string User { get; set; }

        [BsonElement ("borrowed")]
        DateTime Borrowed { get; set; }

        [BsonElement ("returned")]
        DateTime Returned { get; set; }

    }
}
