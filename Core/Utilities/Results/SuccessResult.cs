namespace Core.Utilities.Results;

public class SuccessResult : Result
{
    // Base class'a base içine yazdığımız verileri yollar.
    public SuccessResult(string message):base(true,message)
    {
        
    }

    public SuccessResult():base(true)
    {
        
    }
}