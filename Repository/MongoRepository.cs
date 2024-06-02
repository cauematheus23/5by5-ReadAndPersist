using Models;
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
        

        public bool InsertInMongo(List<Infracao> infracoes)
        {
            bool result = false;
            try
            {
                collection.InsertMany(infracoes);
                result = true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            return result;
        }


    }
}
