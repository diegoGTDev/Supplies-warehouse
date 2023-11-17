namespace WebService.Models.Response
{
    public class Response
    {
        public State Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Response() {
            this.Status = State.Error;
        }
    }

    public enum State
    {
        Success = 1,
        Error = 0
    }  
}
