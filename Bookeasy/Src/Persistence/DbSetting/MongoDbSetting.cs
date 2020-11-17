using Bookeasy.Persistence.Interfaces;

namespace Bookeasy.Persistence.DbSetting
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}