using Models;
using Service;

namespace Controller
{
    public class RPController
    {
        private RPServices _service;
        public RPController()
        {
            _service = new RPServices();
        }
        public List<Infracao> GetAll() { return _service.GetAll(); }
        public List<Infracao> SelectFromMongo() { return _service.SelectFromMongo(); }
    }
}