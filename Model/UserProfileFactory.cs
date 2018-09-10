using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot.Model
{
    public enum TipoRepositorio
    {
        MongoDB,
        SQLServer
    }
    public static class UserProfileFactory
    {
        public static IUserProfileRepository GetRepository(string connectionString)
        { 
            return new UserProfileMongoRepo(connectionString);
        }
        public static IUserProfileRepository GetRepository()
        {
            TipoRepositorio tipoRepositorio = (TipoRepositorio) Enum.Parse(typeof(TipoRepositorio), ConfigurationManager.AppSettings["TipoRepo"].ToString());
            IUserProfileRepository userProfileRepository = null;
            switch (tipoRepositorio)
            {
                case TipoRepositorio.SQLServer:
                    userProfileRepository = new UserProfileSQLServerRepo(ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(TipoRepositorio), tipoRepositorio)].ToString());
                    break;
                default:
                    userProfileRepository = new UserProfileMongoRepo(ConfigurationManager.ConnectionStrings[Enum.GetName(typeof(TipoRepositorio), tipoRepositorio)].ToString());
                    break;
            }
            return userProfileRepository;
        }
    }
}