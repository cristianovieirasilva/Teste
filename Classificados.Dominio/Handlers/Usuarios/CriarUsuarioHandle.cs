using Classificados.Comum.Commands;
using Classificados.Comum.Handlers.Contracts;
using Classificados.Comum.Util;
using Classificados.Dominio.Commands.Usuario;
using Classificados.Dominio.Entidades;
using Classificados.Dominio.Repositorios;
using Flunt.Notifications;

namespace Classificados.Dominio.Handlers.Usuarios
{
    public class CriarUsuarioHandle : Notifiable, IHandlerCommand<CriarContaCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public CriarUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handle(CriarContaCommand command)
        {
            command.Validar(); //Validação Flunt que vem da entidade
                if (command.Invalid)
                    return new GenericCommandResult(false, "Dados do Usuário inválido", command.Notifications); //Mensagem caso usuario seja inválido

            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email); //Procura no banco se email ja esta cadastrado
                if (usuarioExiste != null)
                    return new GenericCommandResult(false, "Email já cadastrado", null); //Mensagem caso email ja esta cadastrado
                
            command.Senha = Senha.Criptografar(command.Senha); //Criptografa a senha

            var usuario = new Usuario(command.Nome, command.Email, command.DataNascimento, command.Senha); 
                if (usuario.Invalid)
                    return new GenericCommandResult(false, "Usuário Inválido", usuario.Notifications); //Mensagem caso usuario seja inválido

            _usuarioRepositorio.Adicionar(usuario); //Adiciona no banco

            return new GenericCommandResult(true, "Usuário Criado", null);  //Retornar uma mensagem de sucesso, pois passou pelas validações
        }
    }
}
