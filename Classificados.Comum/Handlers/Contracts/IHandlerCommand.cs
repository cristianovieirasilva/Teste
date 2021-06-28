using Classificados.Comum.Commands;

namespace Classificados.Comum.Handlers.Contracts
{
    public interface IHandlerCommand<T> where T : ICommand //Herda a validacao de ICommand
    {
        ICommandResult Handle(T command);
    }
}
