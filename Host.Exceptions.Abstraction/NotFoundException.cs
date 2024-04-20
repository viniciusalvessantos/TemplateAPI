namespace Hosted.Exceptions.Abstraction {
    public class NotFoundException : AppException {
        public NotFoundException(string entityId, string entityType) : base($"Entity {entityType} {entityId} was not found.", 9000) {

        }
    }
}
