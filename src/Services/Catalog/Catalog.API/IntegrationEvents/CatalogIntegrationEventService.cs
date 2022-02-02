using Catalog.API.Infrastructure;
using EventBus.Abstractions;
using EventBus.Events;

namespace Catalog.API.IntegrationEvents
{
    public class CatalogIntegrationEventService : ICatalogIntegrationEventService, IDisposable
    {
        private volatile bool disposedValue;
        private readonly IEventBus _eventBus;
        private readonly CatalogContext _catalogContext;

        public CatalogIntegrationEventService(IEventBus eventBus,
                                              CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            try
            {
                _eventBus.Publish(evt);
            }
            catch (Exception ex)
            {
            }
        }

        public async Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt)
        {
            //implement resilience
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //(_eventLogService as IDisposable)?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}
