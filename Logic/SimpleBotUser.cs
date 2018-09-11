using SimpleBot.Model;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        private static SimpleBotUser simpleBotUser;
        private IUserProfileRepository userProfileRepository;
        private SimpleBotUser()
        {
            userProfileRepository = UserProfileFactory.GetRepository();
        }
        public static SimpleBotUser Instancia()
        {
            if (simpleBotUser == null)
                simpleBotUser = new SimpleBotUser();
            return simpleBotUser;
        }
        public string Reply(Message message)
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

        public UserProfile GetProfile(string id)
        {
            UserProfile profile = userProfileRepository.GetProfile(id);
            if (profile == null)
            {
                SetProfile(id, new UserProfile()
                {
                    Id = id
                });
                profile = userProfileRepository.GetProfile(id);
            }
            return profile;
        }

        public void SetProfile(string id, UserProfile profile)
        {
            //if (MongoDBDriver.CriarInstancia().Find(profile.Id) == null)
            //    MongoDBDriver.CriarInstancia().Insert(profile);
            //else
            //    MongoDBDriver.CriarInstancia().Update(profile);
            userProfileRepository.SetProfile(id, profile);
        }
    }
}