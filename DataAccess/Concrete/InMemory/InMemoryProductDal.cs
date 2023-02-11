using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;     
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        readonly List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product(2,1,"Kamera",500,3),
                new Product(3, 2, "Telefon", 1500, 2),
                new Product(4, 2, "Klavye", 10, 65),
                new Product(5, 2, "Fare", 85, 1)
            };
        }

        public List<Product> GetAll(Expression<Func<Product, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product); 
        }

        public void Delete(Product product)
        {
            // Product productToDelete;
            // foreach (var p in _products)
            // {
            //     if (product.ProductID == p.ProductID)
            //     {
            //         productToDelete = p;
            //     }  
            // }
            
            //(p=>...) ifadesi foreach'le aynı görevi üstlenir
            Product productToDelete = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products; 
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;    
        }
        
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList(); 
        }

        public Product Get(Expression<Func<Product, bool>>? filter)
        {
            throw new NotImplementedException();
        }
    }
}
