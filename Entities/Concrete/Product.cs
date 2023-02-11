using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product:IEntity
    {

        public Product(int productId, int categoryId, string productName, short unitsInStock, decimal unitPrice)
        {
            ProductId = productId;
            CategoryId = categoryId;
            ProductName = productName;
            UnitsInStock = unitsInStock;
            UnitPrice = unitPrice;
        }
        public Product()
        {
        }
        
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public short UnitsInStock { get; set; }  
        public decimal UnitPrice { get; set; }
    }
}
