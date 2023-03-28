using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants;
// sürekli newlememek için static kulanılır
// static : sabit, değişmeyen
public static class Messages
{
    public const string ProdcutListed = "Ürün Listelendi";
    public const string ProductNameAlreadyExists = "Bu isimde bir ürün zaten var";
    public const string? AuthorizationDenied = "You have not permition to access";
    public const string? UserRegistered = " Successfully registered";
    public const string? UserNotFound = "User Doesn't exist";
    public const string PasswordError = "Wrong Password";
    public const string AccessTokenCreated = "Token successfully created";
    public const string UserExists = "That User Exists";
    public const string SuccessfulLogin = "Successfully Logged in";
    public static string ProductAdded = "Ürün eklendi";
    public static string ProductNameInvalid = "Ürün ismi geçersiz";
    public static string MaintanceTime = "!!Sistem Bakımda!!";
}