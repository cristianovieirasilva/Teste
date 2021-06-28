using Classificados.Comum.Handlers.Contracts;
using Classificados.Comum.Queries;
using Classificados.Dominio.Queries;
using Classificados.Dominio.Repositorios;
using System.Linq;

namespace Classificados.Dominio.Handlers.Queries
{
    public class ListarProdutoQueryHandle : IHandlerQuery<ListarProdutoQuery>
    {
        private readonly IProdutoRepositorio _repositorio;
        public ListarProdutoQueryHandle(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        /// <summary>
        /// Pega as propriedades no command e aciona o metodo listar
        /// </summary>
        /// <param name="query"></param>
        /// <returns>retorna uma mensagem generica e a listagem</returns>
        public IQueryResult Handle(ListarProdutoQuery query)
        {
            var produtos = _repositorio.Listar();
                
            var Produtos = produtos.Select(
                x =>
                {
                    return new ListarQueryResult()
                    {
                        Titulo = x.Titulo,
                        Descricao = x.Descricao,
                        Categoria = x.Categoria,
                        Imagem = x.Imagem,
                        Preco = x.Preco,
                        Telefone = x.Telefone,
                        Cep = x.Cep
                    };
                }
            );
            return new GenericQueryResult(true, "Produtos", produtos);
        }
    }
}
