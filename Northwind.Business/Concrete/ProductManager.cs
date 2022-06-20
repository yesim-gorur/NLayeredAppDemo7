using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        //managerde IProductdal çağırmalısın çünkü bir alt katmandaki kilit isim ve konstructer oluşturmalısın
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
       


        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(Expression<Func<Product, bool>> filter)
        {
            return _productDal.GetById(filter);
        }

        public void Update(Product product)
        {
           _productDal.Update(product);
        }
    }
}
