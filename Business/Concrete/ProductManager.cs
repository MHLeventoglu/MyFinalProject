using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
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
[ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        // business codes
        /*
        var context = new ValidationContext<Product>(product);
        ProductValidator productValidator = new ProductValidator();
        var result = productValidator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
        */
        
        _productDal.Add(product); 
        return new SuccessResult(product.ProductName + "-" + Messages.ProductAdded);
    }
}