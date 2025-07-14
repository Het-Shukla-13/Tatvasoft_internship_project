namespace MyProject.Entities.ViewModels
{
    public enum ResponseStatus { Success, Error }

    public class ResponseResult<T>
    {
        public ResponseStatus Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
