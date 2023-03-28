
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    // SOLID Principle
    // Open Closed Principle
    class Program
    {
        static void Main()
        {
            Console.WriteLine("hello world");
            // ProductTest();
            // Manager'ları newlemek yerine -IoC- kullanacağız ilerleyen süreçte.
            // CategoryTest();
            //DTO : Data Transformation Object
        }

        // private static void CategoryTest()
        // {
        //     CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //     foreach (var category in categoryManager.GetAll())
        //     {
        //         Console.WriteLine(category.CategoryName);
        //     }
        // }
        //
        // private static void ProductTest()
        // {
        //     ProductManager productManager = new ProductManager(new EfProductDal());
        //     var result = productManager.GetProductDetails();
        //     if (result.Success== true)
        //     {
        //         foreach (var item in result.Data)
        //         {
        //             Console.WriteLine("{0} // {1}",item.ProductName,item.CategoryName);
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine(result.Message);
        //     }
        //     
        // }
    }
}

