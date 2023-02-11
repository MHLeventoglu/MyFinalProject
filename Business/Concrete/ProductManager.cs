using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IDataResult<List<Product>> GetAll()
    {
        //İş kodları
        //Yetkisi var mı? vs...
        if (DateTime.Now.Hour==22)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
        }
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProdcutListed);
    }

    public IDataResult<Product> GetById(int id)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p=> p.ProductId == id));
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
    }

    public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        if (DateTime.Now.Hour==13)
        {
            return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintanceTime);
        }
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    public IResult Add(Product product)
    {
        // business codes
        if (product.ProductName != null && product.ProductName.Length<2)
        {
            return new ErrorResult(Messages.ProductNameInvalid);
        }
        _productDal.Add(product); 
        Console.WriteLine("{0} successfully added",product.ProductName);
        return new SuccessResult(Messages.ProductAdded);
    }
}