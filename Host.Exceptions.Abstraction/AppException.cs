namespace Hosted.Exceptions.Abstraction {
    public abstract class AppException : Exception {
        public int ExceptionCode { get; }

        protected AppException(string message, int exceptionCode) : base(message) {
            ExceptionCode = exceptionCode;
        }
    }
}
