namespace Ecommerce.Core.CQRS
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
    }
}
