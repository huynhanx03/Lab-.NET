using AutoMapper;
using BusinessObject;
using BusinessObject.RequestBody.PrdoductRequest;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class ProductService
    {
        private readonly IRepositoryProduct _repositoryProduct;
        private IMapper _mapper;

        public ProductService
            (
            IRepositoryProduct repositoryProduct,
            IMapper mapper
            )
        {
            _repositoryProduct = repositoryProduct;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetPagingList(ProductRequestBody requestBody)
        {
            try
            {
                var products = await _repositoryProduct.GetList();
                if(!String.IsNullOrEmpty(requestBody.Name))
                {
                    products = products.ToList().Where(x => x.ProductName.Contains(requestBody.Name)).ToList();
                }
                return _mapper.Map<List<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<ProductDto> GetProductById(Guid requestBody)
        {
            try
            {
                var products = await _repositoryProduct.GetById(requestBody);
                return _mapper.Map<ProductDto>(products);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> AddProduct(ProductAddDto product)
        {
            try
            {
                var productAdd = _mapper.Map<Product>(product);
                var addd = await _repositoryProduct.Add(productAdd);
                return addd;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProductDto>> GetProductByIds(ProductRequestBody requestBody)
        {
            try
            {
                var products = await _repositoryProduct.GetProductByIds(requestBody);
                return _mapper.Map<List<ProductDto>>(products);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> RemoveProduct(Guid id)
        {
            try
            {
                var removeProduct = await _repositoryProduct.Delete(id);
                return removeProduct;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
