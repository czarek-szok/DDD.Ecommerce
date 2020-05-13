using System;

namespace Ecommerce.Core.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }

        public TResult Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
        {
            throw new NotImplementedException();
        }
    }
}
