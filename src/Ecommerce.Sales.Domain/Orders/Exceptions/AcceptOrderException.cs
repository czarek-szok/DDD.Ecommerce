using System;


namespace Sales.Domain.Orders.Exceptions
{
    public class AcceptOrderException : Exception
    {
        public AcceptOrderException(Guid orderId, params string[] errorMessages)
        {

        }
    }
}
