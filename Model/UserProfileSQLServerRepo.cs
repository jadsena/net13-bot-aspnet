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
            throw new NotImplementedException();
        }

        public void SetProfile(string id, UserProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}