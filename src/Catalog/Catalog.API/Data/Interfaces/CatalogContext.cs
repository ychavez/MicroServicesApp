using Catalog.API.Entities;
using Catalog.API.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data.Interfaces
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(ICatalogDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            
            var database = client.GetDatabase(settings.DataBaseName);

            products = database.GetCollection<Product>(settings.CollectionName);
            CatalogContextSeed.SeedData(products);
        }
        public IMongoCollection<Product> products { get; }
    }
}
