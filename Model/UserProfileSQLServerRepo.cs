using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Model
{
    public class UserProfileSQLServerRepo : IUserProfileRepository
    {
        private readonly string conn;
        public UserProfileSQLServerRepo(string connectionString)
        {
            conn = connectionString;
        }
        public UserProfile GetProfile(string id)
        {
            return GetProfileSQLServer(id)?.ToUserProfile();
        }

        private UserProfileSQLServer GetProfileSQLServer(string id)
        {
            using (var db = new DbChatBotContext())
            {
                return db.UserProfile.FirstOrDefault(g => g.IdUsuario == id);
            }
        }

        public void SetProfile(string id, UserProfile profile)
        {
            using (var db = new DbChatBotContext())
            {
                UserProfileSQLServer profSQL = GetProfileSQLServer(profile.Id);
                if (profSQL == null)
                    db.UserProfile.Add(UserProfileSQLServer.Parse(profile));
                else
                {
                    profSQL.Visitas = profile.Visitas;
                    db.UserProfile.Update(profSQL);
                }
                db.SaveChanges();
            }
        }
    }
}