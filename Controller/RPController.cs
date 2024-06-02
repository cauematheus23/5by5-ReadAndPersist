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

        public bool InsertInMongo(List<Infracao> infracaoList) { return _service.InsertInMongo(infracaoList); }
    }
}