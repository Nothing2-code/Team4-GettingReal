using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team4ProjectGettingReal.Model;

namespace Team4ProjectGettingReal.Repository
{
    internal interface IRepository
    {
        public ID GetByID(ID id);
        public IEnumerable<ID> GetAll();
        public void Add(ID item);
        public void Update(ID item);
        public void Delete(ID item);
    }
}
