using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ManagerContext>, IProductDal
    {
        // sadece product tablosunu ilgilendiren islemlerin kodlari yazilir 
        // IProductDal deme sebebi sadece product icin gecerli islemleri implemente etmek
        public List<ProductDetailDto> GetProductDetails()
        {
            using (ManagerContext context= new ManagerContext())
            {

                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName                                
                             };
                return result.ToList();
                    
            }
        }
    }
}
