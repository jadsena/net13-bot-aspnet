using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Model
{
    public class UserProfileMongoRepo : IUserProfileRepository
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<UserProfileMongo> col;
        public UserProfileMongoRepo(string connectionString)
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase("net13");
            col = db.GetCollection<UserProfileMongo>("UserProfile");
        }
        public UserProfile GetProfile(string id)
        {
            var filter = Builders<UserProfileMongo>.Filter.Eq(g => g.Id, id);
            UserProfileMongo userProfileMongo = col.Find(filter).FirstOrDefault();
            return userProfileMongo?.ToUserProfile();
        }

        public void SetProfile(string id, UserProfile profile)
        {
            var filter = Builders<UserProfileMongo>.Filter.Eq(g => g.Id, profile.Id);
            col.ReplaceOne(filter, UserProfileMongo.Parse(profile), new UpdateOptions { IsUpsert=true });
        }
    }
}