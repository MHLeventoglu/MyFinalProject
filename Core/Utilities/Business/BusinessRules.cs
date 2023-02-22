using Core.Utilities.Results;

namespace Core.Utilities.Business;

public class BusinessRules
{
    public static IResult Run(params IResult[] logics) //params means u can add params as much as u want
    {
        foreach (var logic in logics)
        {
            if (!logic.Success)
            {
                return logic;
            }
        }

        return null;
    }
}   