using Classificados.Comum.Queries;

namespace Classificados.Comum.Handlers.Contracts
{
    public interface IHandlerQuery<T> where T : IQuery //Herda a validacao de IQuery
    {
        IQueryResult Handle(T query);
    }
}
