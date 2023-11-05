using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_06.Logic
{
    public interface ILogic<T> where T : class
    {
        void Create(T t);
        T Get(string id);
        IQueryable<T> GetAll();
        void Delete(string id);
    }
}
