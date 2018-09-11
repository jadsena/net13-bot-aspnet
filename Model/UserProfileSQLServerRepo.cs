using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Model
{
    public class UserProfileSQLServerRepo : IUserProfileRepository
    {
        public UserProfileSQLServerRepo(string connectionString)
        {

        }
        public UserProfile GetProfile(string id)
        {
            using (var db = new DbChatBotContext())
            {
                return db.UserProfile.FirstOrDefault(g => g.IdUsuario == id).ToUserProfile();
                //if (db.UserProfile.Count(g => g.IdUsuario == id) > 0)
                    //return db.UserProfile.SingleOrDefault(g => g.IdUsuario == id).ToUserProfile();
                //else
                //    return null;
            }
        }

        public void SetProfile(string id, UserProfile profile)
        {
            using (var db = new DbChatBotContext())
            {
                if (GetProfile(profile.Id) == null)
                    db.UserProfile.Add(UserProfileSQLServer.Parse(profile));
                else
                    db.UserProfile.Update(UserProfileSQLServer.Parse(profile));
            }
        }
    }
}