using System;
using System.Collections.Generic;

namespace SimpleBot.Model
{
    public class UserProfileSQLServer
    {
        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public int Visitas { get; set; }
        public UserProfile ToUserProfile()
        {
            return new UserProfile
            {
                Id = this.IdUsuario,
                Visitas = this.Visitas
            };
        }

        public static UserProfileSQLServer Parse(UserProfile userProfile)
        {
            return new UserProfileSQLServer
            {
                IdUsuario = userProfile.Id,
                Visitas = userProfile.Visitas
            };
        }
    }
}
