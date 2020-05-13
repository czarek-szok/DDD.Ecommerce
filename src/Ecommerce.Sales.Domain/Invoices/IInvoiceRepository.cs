using System;

namespace Sales.Domain.Invoices
{
    public interface IInvoiceRepository
    {
        Invoice Get(Guid Id);
        void Save(Invoice invoice);
    }
}
