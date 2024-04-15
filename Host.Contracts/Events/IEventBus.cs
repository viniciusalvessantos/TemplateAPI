namespace Hosted.Contracts.Events {
    public interface IEventBus {
        public Task Publish(IIntegrationEvent @event);
        Task PublishMany(IEnumerable<IIntegrationEvent> @events);
    }
}
