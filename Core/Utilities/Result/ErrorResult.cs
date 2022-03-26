namespace Core.Utilities.Result
{
    public class ErrorResult : Result
    {
        // base Result claasina gondermesini saglar
        // hem mesaj hem true donmesi icin yazilan constructor
        public ErrorResult(string message) : base(false, message)
        {

        }
        // mesaj yok sadece true donmesi icin yazilan constructor
        public ErrorResult() : base(false)
        {

        }
    }
}
