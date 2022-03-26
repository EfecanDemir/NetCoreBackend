using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    // Entity Framework kullanilan tum projelerde ayni
    // TEntity --> Car,Product,Ship gibi ifadeler olabilir
    // TContext --> DbContextden inherit edilmis bir yapi olmali

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // neden using ??
            //disposable pattern 
            //using bittigi anda garbage collector bellekten temizler
            using (TContext context = new TContext())
            {
                //referansi yakala
                var addedEntity = context.Entry(entity);
                //nesne durumunu belirle
                addedEntity.State = EntityState.Added;
                //degisikligi kaydet
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                // referans tut
                var deletedEntity = context.Entry(entity);
                // nesne durumunu belirle
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                // filtre null ise tum listeyi yaz
                // filtre varsa filtreye gore listele
                //tirnary if
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                // referans tut
                var updatedEntity = context.Entry(entity);
                // nesne durumunu belirle
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}