using Classificados.Comum.Handlers.Contracts;
using Classificados.Comum.Queries;
using Classificados.Dominio.Queries;
using Classificados.Dominio.Repositorios;

namespace Classificados.Dominio.Handlers.Queries
{
    public class BuscarProdutoQueryHandle : IHandlerQuery<BuscarProdutoQuery>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public BuscarProdutoQueryHandle(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        /// <summary>
        /// Pega as propriedades no command "BuscarProdutoQuery", após usuario buscar pelo titulo
        /// </summary>
        /// <param name="query"></param>
        /// <returns>retorna uma mensagem generica e a listagem</returns>
        public IQueryResult Handle(BuscarProdutoQuery query)
        {
            var produto = _produtoRepositorio.BuscarPorTitulo(query.Titulo);

            if (produto == null)
                return new GenericQueryResult(false, "Produto não encontrado", null);

            var Produto = new BuscarProdutoQueryResult
            {
                Titulo = produto.Titulo,
                Descricao = produto.Descricao,
                Categoria = produto.Categoria,
                Imagem = produto.Imagem,
                Preco = produto.Preco,
                Telefone = produto.Telefone,
                Cep = produto.Cep,
                IdUsuario = produto.IdUsuario
            };

            return new GenericQueryResult(true, "Produto encontrado", Produto);
        }
    }
}
