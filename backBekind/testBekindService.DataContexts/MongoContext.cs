using MongoDB.Driver;
using testBekind.Domain;

namespace testBekindService.DataContexts
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        // Constructor que recibe las configuraciones necesarias para la conexión.
        public MongoContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        //Una colección llamada 'Products'
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");


        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    }

}
