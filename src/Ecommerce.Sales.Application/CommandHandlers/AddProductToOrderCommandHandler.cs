using Ecommerce.Core.CQRS;
using Sales.Domain.Orders;
using Sales.Domain.Orders.Policies.Discount;
using Sales.Interfaces.Commands;

namespace Sales.Application.CommandHandlers
{
    public class AddProductToOrderCommandHandler : ICommandHandler<AddProductToOrderCommand>
    {
        private readonly IDiscountPolicyFactory _discountPolicyFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public AddProductToOrderCommandHandler(IDiscountPolicyFactory discountPolicyFactory,
                                               IOrderRepository orderRepository,
                                               IProductRepository productRepository)
        {
            _discountPolicyFactory = discountPolicyFactory;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public void Handle(AddProductToOrderCommand command)
        {
            var order = _orderRepository.Get(command.OrderId);
            var product = _productRepository.Get(command.ProductId);
            var discount = _discountPolicyFactory.Create(order.Customer);

            order.ApplyDiscount(discount);
            order.AddProduct(product, command.Quantity);

            _orderRepository.Save(order);
        }
    }
}
