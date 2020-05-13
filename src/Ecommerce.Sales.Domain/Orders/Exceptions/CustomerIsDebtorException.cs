using System;

namespace Sales.Application.Exceptions
{
    public class CustomerIsDebtorException : Exception
    {
        public CustomerIsDebtorException(Guid customerId)
        {

        }
    }
}
