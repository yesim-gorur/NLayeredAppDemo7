using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(Expression<Func<Category, bool>> filter);
        void Update(Category category);
        void Delete(Category category);
        void Add(Category category);

    }
}
