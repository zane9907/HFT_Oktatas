using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora06.Repository
{
    public interface IRepository<T>
    {
        T Get(string id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Delete(string id);
    }
}
