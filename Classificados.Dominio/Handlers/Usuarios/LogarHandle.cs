using Classificados.Comum.Commands;
using Classificados.Comum.Handlers.Contracts;
using Classificados.Comum.Util;
using Classificados.Dominio.Commands.Usuario;
using Classificados.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classificados.Dominio.Handlers.Usuarios
{
    public class LogarHandle : IHandlerCommand<LogarCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LogarHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handle(LogarCommand command)
        {
            //Validar Command
            command.Validar();
                if (command.Invalid)
                    return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            
            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email); //Buscar usário pelo e-mail
                if (usuario == null)
                   return new GenericCommandResult(false, "E-mail inválido", null); //Mensagem caso e-mail invalido ou nao cadastrado

            //Verificar senha é valida
            if (!Senha.Validar(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha inválida", null); //Mensagem caso senha invalida

            return new GenericCommandResult(true, "Usuário Logado", usuario); //Retornar mensagem de sucesso e dados do usuário
        }
    }
}
