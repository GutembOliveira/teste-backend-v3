using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.IO;
namespace TheatricalPlayersRefactoringKata
{
    public  class DbConfig
    {

        public  static string GetConnectionString()
        {
            try
            {
                string connectionString ="mongodb+srv://Gutemberg:Chernobyl371@cluster0.ur14plj.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

                return connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler a connection string: " + ex.Message);
                throw;
            }
        }

        public static  IMongoDatabase GetDatabase(string databaseName = "theaterDB")
        {
            try
            {
                string connectionString = GetConnectionString();
                var client = new MongoClient(connectionString);
                return client.GetDatabase(databaseName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao MongoDB: " + ex.Message);
                throw;
            }
        }
    }
}

