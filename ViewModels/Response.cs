namespace MyProductApi.ViewModels
{
    public class Response
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        public Response(bool success)
        {
            Success = success;
        }

        public Response(bool success, List<string> errors) : this(success)
        {
            Errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }
    }
}
