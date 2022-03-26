namespace Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //hem data hem mesaj hemde false dondurebilir
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        // sadece data ve false dondurebilir
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //datayı default atıip mesaj ve false dondurebilir
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        // datayi default atip sadece false dondurebilir
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
