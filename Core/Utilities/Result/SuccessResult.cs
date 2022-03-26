namespace Core.Utilities.Result
{
    public class SuccessResult:Result
    {
        // base Result claasina gondermesini saglar
        // hem mesaj hem true donmesi icin yazilan constructor
        public SuccessResult(string message) : base(true, message)
        {

        }
        // mesaj yok sadece true donmesi icin yazilan constructor
        public SuccessResult() : base(true)
        {

        }
    }
}
