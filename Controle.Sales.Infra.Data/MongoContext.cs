using Infra.Data.AppConfig;
using Domain.DomainEntities;
using MongoDB.Driver;

namespace Infra.Data
{
    public class MongoContext
    {
        //private readonly MongoClient mongoClient;
        //private readonly IMongoDatabase database;
        //public IConfigurationRoot Configuration { get; }

        private readonly string _collectionName;

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        public MongoContext(string strCollectionName)
        {
            //Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //mongoClient = new MongoClient(Configuration["MongoDB:ConnectionString"]);
            //database = mongoClient.GetDatabase(Configuration["MongoDB:Database"]);

            //---> Call API mongo Azure
            this._collectionName = strCollectionName;
            this._client = new MongoClient(AppConfiguration.GetConfiguration("ServerName"));
            this._database = _client.GetDatabase(AppConfiguration.GetConfiguration("DatabaseName"));

        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;

        public IMongoCollection<Sale> Sales =>
            //return database.GetCollection<Sale>("collection_Sale"); 
            _database.GetCollection<Sale>(_collectionName);
    }
}

