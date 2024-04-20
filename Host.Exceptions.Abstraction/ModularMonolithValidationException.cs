namespace Hosted.Exceptions.Abstraction {
    public abstract class ModularMonolithValidationException : AppException {
        public List<string> ValidationMessages { get; set; }
        protected ModularMonolithValidationException(string message, int exceptionCode) : base(message, exceptionCode) {
        }
    }
}
