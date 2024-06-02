using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MongoRepository
    {
        private readonly string strConexaoMongo = "mongodb://root:Mongo%402024%23@localhost:27017";
        IMongoDatabase database;
        IMongoCollection <Infracao> collection;
        MongoClient conn;

        public MongoRepository(){
            conn = new MongoClient(strConexaoMongo);
            database = conn.GetDatabase("Radar");
            collection = database.GetCollection<Infracao>("Infracoes");

        }
        

        public List<Infracao> SelectFromMongo()
        {
          
            try
            {
                var projection = Builders<Infracao>.Projection.Exclude(x => x._id);
                return collection.Find(_ => true).ToList();
          
               
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            return new List<Infracao>();
        }
       

    }
}
