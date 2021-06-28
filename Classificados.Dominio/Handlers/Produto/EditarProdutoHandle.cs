using Classificados.Comum.Commands;
using Classificados.Comum.Handlers.Contracts;
using Classificados.Dominio.Commands.Produto;
using Classificados.Dominio.Repositorios;

namespace Classificados.Dominio.Handlers.Produto
{
    public class EditarProdutoHandle : IHandlerCommand<EditarProdutoCommand>
    {
        private readonly IProdutoRepositorio _repositorio;
        public EditarProdutoHandle(IProdutoRepositorio produto)
        {
            _repositorio = produto;
        }

        public ICommandResult Handle(EditarProdutoCommand command)
        {
            command.Validar(); //Validação Flunt que vem da entidade
                 if (command.Invalid)
                    return new GenericCommandResult(true, "Dados inválidos", command.Notifications);

            var produto = _repositorio.BuscarPorId(command.Id); //Verifica se o produto existe
                 if (produto == null)
                    return new GenericCommandResult(false, "Produto não encontrado", null); //Mensagem caso produto não exista

            var pacoteexiste = _repositorio.BuscarPorTitulo(command.Titulo); //Verifica se existe produto com o mesmo titulo
                if (pacoteexiste != null)
                    return new GenericCommandResult(true, "Titulo do pacote já cadastrado", null); //Mensagem caso título do produto já exista

            produto.AtualizarProduto(command.Titulo, command.Descricao, command.Categoria, command.Imagem, command.Preco, command.Telefone, command.Cep);
                if (produto.Invalid)
                    return new GenericCommandResult(false, "Dados inválidos", produto.Notifications); //Mensagem caso dados inválidos

            _repositorio.Alterar(produto); //Altera o produto

            //Retornar uma mensagem de sucesso, pois passou pelas validações
            return new GenericCommandResult(true, "Pacote Alterado", null);
        }

    }
}