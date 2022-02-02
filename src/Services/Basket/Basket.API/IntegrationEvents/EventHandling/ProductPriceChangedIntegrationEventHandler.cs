using Basket.API.IntegrationEvents.Events;
using EventBus.Abstractions;

namespace Basket.API.IntegrationEvents.EventHandling
{
    public class ProductPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ProductPriceChangedIntegrationEvent>
    {
        public async Task Handle(ProductPriceChangedIntegrationEvent @event)
        {
            //throw new NotImplementedException();
        }
    }
}
