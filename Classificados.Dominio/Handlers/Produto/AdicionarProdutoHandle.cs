using Classificados.Comum.Commands;
using Classificados.Comum.Handlers.Contracts;
using Classificados.Dominio.Commands.Produto;
using Classificados.Dominio.Entidades;
using Classificados.Dominio.Repositorios;

namespace Classificados.Dominio.Handlers.Produto
{
    public class AdicionarProdutoHandle : IHandlerCommand<AdicionarProdutoCommand>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public AdicionarProdutoHandle(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public ICommandResult Handle(AdicionarProdutoCommand command)
        {
            command.Validar(); //Validação Flunt que vem da entidade
                if (command.Invalid)
                    return new GenericCommandResult(true, "Dados inválidos", command.Notifications); //Mensagem caso produto seja inválido

            var produtoexiste = _produtoRepositorio.BuscarPorTitulo(command.Titulo);  //Verifica se existe produto com o mesmo titulo
                if (produtoexiste != null)
                    return new GenericCommandResult(true, "Titulo do produto já cadastrado", null); //Mensagem caso título do produto já exista

            var produto = new Produtos(command.Titulo, command.Descricao, command.Categoria, command.Imagem, command.Preco, command.Telefone, command.Cep, command.IdUsuario);
                if (produto.Invalid)
                    return new GenericCommandResult(true, "Dados inválidos", produto.Notifications); //Mensagem caso produto seja inválido

            _produtoRepositorio.Adicionar(produto); //Adicionar produto
         
            return new GenericCommandResult(true, "Produto criado", produto); //Retornar uma mensagem de sucesso, pois passou pelas validações
        }
    }
}
