using Classificados.Comum.Commands;
using Classificados.Comum.Handlers.Contracts;
using Classificados.Dominio.Commands.Produto;
using Classificados.Dominio.Repositorios;

namespace Classificados.Dominio.Handlers.Produto
{
    public class ExcluirProdutoHandle : IHandlerCommand<ExcluirProdutoCommand>
    {
        private IProdutoRepositorio _repositorio { get; set; }
        public ExcluirProdutoHandle(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(ExcluirProdutoCommand command)
        {
            var produto = _repositorio.BuscarPorId(command.Id); //Verifica se o produto existe
                if (produto == null)
                    return new GenericCommandResult(false, "Produto Inexistente!", null); //Mensagem de erro caso produto não exista

            _repositorio.Excluir(produto.Id); //Exclui o produto

            //Retornar uma mensagem de sucesso, pois passou pelas validações
            return new GenericCommandResult(true, "Produto Deletado!", null);
        }
    }
}