using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
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

        public IMongoCollection<ToDoItem> ToDos
        {
            get
            {
                return _dataBase.GetCollection<ToDoItem>("ToDoItems");
            }
        }
        public IMongoCollection<User> Users
        {
            get
            {
                return _dataBase.GetCollection<User>("Users");
            }
        }

        public IMongoCollection<Account> Accounts
        {
            get
            {
                return _dataBase.GetCollection<Account>("Accounts");
            }
        }


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

            BsonClassMap.RegisterClassMap<Account>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
