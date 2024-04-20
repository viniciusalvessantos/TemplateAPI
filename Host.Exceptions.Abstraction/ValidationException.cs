namespace Hosted.Exceptions.Abstraction {
    public abstract class ValidationException : AppException {
        public List<string> ValidationMessages { get; set; }
        protected ValidationException(string message, int exceptionCode) : base(message, exceptionCode) {
        }
    }
}
