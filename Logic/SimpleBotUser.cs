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
            //var client = new MongoClient("mongodb://localhost:27017");
            //var db = client.GetDatabase("db01");
            //var col = db.GetCollection<BsonDocument>("tabela1");
            //var doc = new BsonDocument()
            //{
            //    { "id", message.Id},
            //    { "texto", message.Text}
            //};
            //col.InsertOne(doc);

            var id = message.Id;
            var profile = GetProfile(id);
            profile.Visitas += 1;

            SetProfile(id, profile);

            return $"{message.User} disse '{message.Text}' visitas '{profile.Visitas}'";
        }

        public static UserProfile GetProfile(string id)
        {
            UserProfile profile = MongoDBDriver.CriarInstancia().Find(id);
            if (profile == null) {
                MongoDBDriver.CriarInstancia().Insert(new UserProfile()
                {
                    Id = id
                });
                profile = MongoDBDriver.CriarInstancia().Find(id);
            }
            return profile;
        }

        public static void SetProfile(string id, UserProfile profile)
        {
            if (MongoDBDriver.CriarInstancia().Find(profile.Id) == null)
                MongoDBDriver.CriarInstancia().Insert(profile);
            else
                MongoDBDriver.CriarInstancia().Update(profile);
        }
    }
}