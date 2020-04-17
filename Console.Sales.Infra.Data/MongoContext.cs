using Controle.Sales.Domain.DomainEntities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.IO;

namespace Controle.Sales.Infra.Data
{
    public class MongoContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;
        public IConfigurationRoot Configuration { get; }

        public MongoContext()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            mongoClient = new MongoClient(Configuration["MongoDB:ConnectionString"]);
            database = mongoClient.GetDatabase(Configuration["MongoDB:Database"]);
        }

        public IMongoCollection<Sale> Sales
        {
            get
            {
                return database.GetCollection<Sale>("collection_Sale");
            }
        }
    }
}
