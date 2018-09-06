using MongoDB.Driver;
using MongoDB.Bson;
using SimpleBot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        public static string Reply(Message message)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("db01");
            var col = db.GetCollection<BsonDocument>("tabela1");
            var doc = new BsonDocument()
            {
                { "id", message.Id},
                { "texto", message.Text}
            };
            col.InsertOne(doc);
            return $"{message.User} disse '{message.Text}'";
        }

        public static UserProfile GetProfile(string id)
        {
            return null;
        }

        public static void SetProfile(string id, UserProfile profile)
        {
            MongoDBDriver.CriarInstancia().Insert(profile);
        }
    }
}