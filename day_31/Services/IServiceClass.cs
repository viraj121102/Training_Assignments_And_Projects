using Repos.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IServiceClass<T> where T : class
    {
        private readonly IRepogeneric<T> _repo;
        public IServiceClass(IRepogeneric<T> repo)
        {
            _repo = repo;
        }
        
        public IEnumerable<T> GetList()
        {
            return _repo.GetAll();
        }
        public string Create(T Obj)
        {
            return _repo.Create(Obj);
        }
    }
}
