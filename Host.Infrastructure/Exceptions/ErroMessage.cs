namespace Hosted.Infrastructure.Exceptions {
    public class ErroMessage {
        public ErroMessage(int statusCode, string message) {
            StatusCode = statusCode;
            Message = message;
        }
        public int StatusCode { get; }
        public string Message { get; }
    }
}
