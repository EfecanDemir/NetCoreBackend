using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        // tablo icin kullanilacak metotlarin imzalari belirtilir
        // metotlar burada ozellestirilir
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IResult Add(Product product);
        IDataResult<List<Product>> GetProductByStock(decimal min, decimal max);
        IResult TransactionalOperation(Product product);
    }
}
