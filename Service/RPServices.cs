using Models;
using Repositories;
using Repository;

namespace Service
{
    public class RPServices
    {
        SQLRepository _sqlrepository;
        MongoRepository _mongorepository;


        public RPServices() 
        { 
            _sqlrepository = new SQLRepository();
            _mongorepository = new MongoRepository();
        }
        public List<Infracao> SelectFromMongo() { return _mongorepository.SelectFromMongo(); }
        public List<Infracao> GetAll() { return _sqlrepository.GetAll(); }
    }
}