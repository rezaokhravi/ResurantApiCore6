namespace Core6.Models.Entites
{
   public class ResponseResult
    {
        public bool IsSucess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Error { get; set; }
        public dynamic Data { get; set; }
        
    }
}