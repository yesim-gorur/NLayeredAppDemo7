using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//burda filtre null degerini alabiliyor
        T GetById(Expression<Func<T,bool>> filter);// burda ise alamıyor
        void Delete(T entity);
        void Update (T entity);
        void Add(T entity);

    }
}
