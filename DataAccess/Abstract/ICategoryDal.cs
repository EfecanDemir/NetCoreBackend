using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        // sadece product tablosunu ilgilendiren islemlerin(join) imzasi burada yazilir
    }
}