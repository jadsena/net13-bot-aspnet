using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Data
{
    public class MongoDBDriver
    {
        private static MongoDBDriver mongoDBDriver;
        private MongoClient cliente;
        private IMongoDatabase db;
        private IMongoCollection<UserProfile> col;
        private MongoDBDriver()
        {
            cliente = new MongoClient();
            db = cliente.GetDatabase("net13");
            col = db.GetCollection<UserProfile>("UserProfile");
        }
        public static MongoDBDriver CriarInstancia()
        {
            if (mongoDBDriver == null)
                mongoDBDriver = new MongoDBDriver();
            return mongoDBDriver;
        }

        public void Insert(UserProfile userProfile)
        {
            col.InsertOne(userProfile);
        }
        public void Update(UserProfile userProfile)
        {
            var filter = Builders<UserProfile>.Filter.Eq(g => g.Id, userProfile.Id);
            col.ReplaceOne(filter, userProfile);
        }
        public UserProfile Find(string id)
        {
            var filter = Builders<UserProfile>.Filter.Eq(g => g.Id, id);
            return col.Find(filter).First();
        }
    }
}