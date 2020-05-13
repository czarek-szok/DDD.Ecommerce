using System;

namespace Sales.Application.Exceptions
{
    public class OverduedOrderException : Exception
    {
        public OverduedOrderException(Guid orderId)
        {

        }
    }
}
