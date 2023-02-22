using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    private ICategoryService _categoryService;
    

    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal = productDal;
        _categoryService = categoryService;
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
    
    
    // [SecuredOperation("product.add,admin")] // ("product.add,admin") is called as "Claim"
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        
       IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                                        CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                                                    CheckIfCategoryOverCount(product.CategoryId));
        if (result!=null)
        {
            return result;
        }
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
        
        
        if (!CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
        {
            return new ErrorResult();
        }
        if (!CheckIfProductNameExist(product.ProductName).Success)
        {
            return new ErrorResult();
        }
        
        // business codes
        _productDal.Add(product); 
        return new SuccessResult(product.ProductName + "-" + Messages.ProductAdded);
    }
    public IResult Update(Product product)
    {
        if (!CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
        {
            return new ErrorResult();
        }
        // business codes
        _productDal.Update(product); 
        return new SuccessResult();
    }

    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        int result = _productDal.GetAll().Count(x => x.CategoryId ==categoryId);
        if (result>=15)
        {
            return new ErrorResult("A category can't contain more than 10 products");
        }

        return new ErrorResult();
    }

    private IResult CheckIfProductNameExist(string productName)
    {
        bool result = _productDal.GetAll(p => p.ProductName == productName).Any();
        if (result)
        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }

        return new SuccessResult();
    }
    private IResult CheckIfCategoryOverCount(int CategoryID)
    {
        int result = _categoryService.GetAll().Data.Count();
        if (result>15)
        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }

        return new SuccessResult();
    }
}