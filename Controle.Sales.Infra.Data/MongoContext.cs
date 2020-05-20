using Controle.Sales.Domain.DomainEntities;
using Controle.Sales.Infra.Data.AppConfig;
using MongoDB.Driver;


namespace Controle.Sales.Infra.Data
{
    public class MongoContext
    {
        //private readonly MongoClient mongoClient;
        //private readonly IMongoDatabase database;
        //public IConfigurationRoot Configuration { get; }

        private string _connectionStrings = string.Empty;
        private string _databaseName = string.Empty;
        private string _collectionName = string.Empty;

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        public MongoContext(string strCollectionName)
        {
            //Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //mongoClient = new MongoClient(Configuration["MongoDB:ConnectionString"]);
            //database = mongoClient.GetDatabase(Configuration["MongoDB:Database"]);

            //---> Call API mongo Azure
            this._collectionName = strCollectionName;
            this._connectionStrings = AppConfiguration.GetConfiguration("ServerName");
            this._databaseName = AppConfiguration.GetConfiguration("DatabaseName");
            this._client = new MongoClient(_connectionStrings);
            this._database = _client.GetDatabase(_databaseName);

        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoDatabase Database
        {
            get { return _database; }
        }

        public IMongoCollection<Sale> Sales
        {
            get
            {
                //return database.GetCollection<Sale>("collection_Sale"); 
                return _database.GetCollection<Sale>(_collectionName);
            }
        }
    }
}

