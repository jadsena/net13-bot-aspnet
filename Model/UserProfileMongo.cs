using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Model
{
    [BsonIgnoreExtraElements]
    public class UserProfileMongo
    {
        public string Id { get; set; }
        public int Visitas { get; set; }

        public UserProfile ToUserProfile()
        {
            return new UserProfile
            {
                Id=this.Id,
                Visitas=this.Visitas
            };
        }

        public static UserProfileMongo Parse(UserProfile userProfile)
        {
            return new UserProfileMongo
            {
                Id = userProfile.Id,
                Visitas = userProfile.Visitas
            };
        }
    }
}