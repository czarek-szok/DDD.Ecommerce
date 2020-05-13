using Ecommerce.Core.CQRS;

using Sales.Domain.Orders;
using Sales.Interfaces.Commands;


namespace Sales.Application.CommandHandlers
{
    public class AcceptOrderCommandHandler : ICommandHandler<AcceptOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public AcceptOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Handle(AcceptOrderCommand command)
        {
            var order = _orderRepository.Get(command.OrderId);

            order.Accept();

            _orderRepository.Save(order);
        }
    }
}
