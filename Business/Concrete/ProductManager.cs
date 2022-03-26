using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // dependency injection : uygulamanın calisacagi ve bagimli oldugu akislari
        // disaridan enjekte ederek uygulama akisini dinamik olarak degistirebilir

        //EfProductDal efProductDal= new EfProductDal(); --> tam baglilik
        IProductDal _productDal; // gevsek baglilik
       
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        // Cross Cutting Concerns
        // AOP--> 
        [ValidationAspect(typeof(ProductValidator),Priority = 1)]
        [SecuredOperation("admin",Priority = 2)]
        [CacheRemoveAspect("IProductService.Get")] // Get metotlarinin cache'lerini sil
        public IResult Add(Product product)
        {
                
            _productDal.Add(product);
            return new SuccessResult(Messages.productAdded);
        }
        [PerformanceAspect(5)]
        public IDataResult<List<Product>> GetAll()
        {
            Thread.Sleep(5000);
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result);
        }
       
        [CacheAspect(duration:10)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId);
            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<List<Product>> GetProductByStock(decimal min, decimal max)
        {
            var result = _productDal.GetAll(p => p.UnitsInStock >= min && p.UnitsInStock <= max);
            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var result = _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result);
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            //_productDal.Add(product);
            return new SuccessResult(Messages.productAdded);
        }
           
    }
}
