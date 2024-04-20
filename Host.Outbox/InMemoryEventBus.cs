using Hosted.Contracts.Events;
using Hosted.Outbox.Entities;
using Hosted.Outbox.Persistence;

namespace Hosted.Outbox {
    public class InMemoryEventBus : IEventBus {
        private readonly OutboxDbContext _dbContext;
        public InMemoryEventBus(OutboxDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task Publish(IIntegrationEvent @event) {
            await PersistIntegrationEvent(@event);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }


        public async Task PublishMany(IEnumerable<IIntegrationEvent> events) {
            foreach (var @event in @events) {
                await PersistIntegrationEvent(@event);
            }

            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        private async Task PersistIntegrationEvent(IIntegrationEvent @event) {
            var outBoxMessage = OutBoxMessage.New(@event);
            await _dbContext.OutBoxMessages.AddAsync(outBoxMessage);
        }
    }
}
