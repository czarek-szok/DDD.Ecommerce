namespace Ecommerce.Core.CQRS
{
    public interface ICommand
    {
    }

    public interface ICommand<T> : ICommand
    {
    }
}
