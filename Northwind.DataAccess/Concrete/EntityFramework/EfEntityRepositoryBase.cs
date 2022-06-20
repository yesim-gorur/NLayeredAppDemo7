using Northwind.DataAccess.Abstract;
using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context=new TContext())
            {
               var addedEntity=context.Entry(entity);//elimdeki enttiy ile veritabanındakini eşleştir ama bulamayacaksın
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedValues = context.Entry(entity);
                deletedValues.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                
                return 
                    filter==null? //filtre null ise
                    context.Set<TEntity>().ToList() :// eger filtre null ise tamamını listele degilse
                    context.Set<TEntity>().Where(filter).ToList();
               

            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                return  context.Set<TEntity>().FirstOrDefault(filter);

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                var updatedValues = context.Entry(entity);
                updatedValues.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
