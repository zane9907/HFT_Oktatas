using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora06.Logic
{
    public interface ILogic<T>
    {
        T Get(string id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Delete(string id);
    }
}
