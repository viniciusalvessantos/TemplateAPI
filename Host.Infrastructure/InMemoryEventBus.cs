using Host.Contracts.Events;

namespace Host.Infrastructure {
    public class InMemoryEventBus : IEventBus {
        public Task Publish(IIntegrationEvent @event) {
            throw new NotImplementedException();
        }

        public Task PublishMany(IEnumerable<IIntegrationEvent> events) {
            throw new NotImplementedException();
        }
    }
}
