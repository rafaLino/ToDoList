using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ToDo.Infrastructure.Entities;

namespace ToDo.Infrastructure
{
    public class Context
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _dataBase;

        private readonly ToDoAppConfig _config;

        public Context(IOptions<ToDoAppConfig> config)
        {
            _config = config.Value;
            _mongoClient = new MongoClient(_config.ConnectionString);
            _dataBase = _mongoClient.GetDatabase(_config.DataBase);
            Map();
        }

        public IMongoCollection<ToDoItem> ToDos { get; set; }
        public IMongoCollection<User> Users { get; set; }

        public IMongoCollection<Account> Accounts { get; set; }


        private void Map()
        {
            BsonClassMap.RegisterClassMap<ToDoItem>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
