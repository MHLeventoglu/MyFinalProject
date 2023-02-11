using System.Net.Http.Headers;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<List<Product>> GetAll();
    IDataResult<Product> GetById(int id);
    IDataResult<List<Product>> GetAllByCategoryId(int id);
    IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);
    IDataResult<List<ProductDetailDto>> GetProductDetails();
    IResult Add(Product product);
    
}