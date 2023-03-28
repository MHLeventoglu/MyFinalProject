using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper //test amaçlı bir token üreteceğimiz zaman
                              //ya da yeni bir sistem kullanacağımız zaman işimize yarar.
{
    AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}