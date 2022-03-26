using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // veritabani islemleri ortak oldugu icin generic yapi IEntityRepository olusturuldu
    // T yi kisitladik : class olmali,
    // veritabani tablolarindan biri olmali,
    // newlenebilmeli IEntity yazilmamali
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // neden expression ???
        // hem tum datayi hemde filtreli datalari getirebildigi icin
        //p=>p.categoryId==2 olani getirme islemi icin yazilir
        //bu yapi sayesinde her filtre icin ayri ayri metot yazmaya gerek kalmaz
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
