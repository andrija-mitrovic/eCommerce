using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration[Constants.MongoDbConnectionString]);
            var database = client.GetDatabase(configuration[Constants.MongoDbDatabaseConnectionString]);

            Products = database.GetCollection<Product>(configuration[Constants.MongoDbConnectionName]);
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
