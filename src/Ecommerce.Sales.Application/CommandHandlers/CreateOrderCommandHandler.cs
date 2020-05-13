using Ecommerce.Core.CQRS;
using Sales.Domain.Orders;
using Sales.Interfaces.Commands;

namespace Sales.Application.CommandHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderFactory _orderFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public CreateOrderCommandHandler(IOrderFactory orderFactory,
                                         IOrderRepository orderRepository,
                                         ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _orderFactory = orderFactory;
        }

        public void Handle(CreateOrderCommand command)
        {
            var customer = _customerRepository.Get(command.CustomerId);

            var order = _orderFactory.Create(customer);

            _orderRepository.Save(order);
        }
    }
}
