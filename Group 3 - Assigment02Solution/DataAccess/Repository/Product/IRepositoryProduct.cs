using BusinessObject;
using BusinessObject.RequestBody.PrdoductRequest;

namespace DataAccess.Repository 
{
    public interface IRepositoryProduct : InterfaceBase<Product>
    {
        Task<IEnumerable<Product>> GetProductByIds(ProductRequestBody requestBody);
    }
}
