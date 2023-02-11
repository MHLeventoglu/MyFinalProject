using Entities.Concrete;

namespace Business.Constants;
// sürekli newlememek için static kulanılır
// static : sabit, değişmeyen
public static class Messages
{
    public const string ProdcutListed = "Ürün Listelendi";
    public static string ProductAdded = "Ürün eklendi";
    public static string ProductNameInvalid = "Ürün ismi geçersiz";
    public static string MaintanceTime = "!!Sistem Bakımda!!";
}