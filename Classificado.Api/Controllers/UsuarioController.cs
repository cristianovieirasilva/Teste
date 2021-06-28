using Classificados.Comum.Commands;
using Classificados.Dominio.Commands.Usuario;
using Classificados.Dominio.Entidades;
using Classificados.Dominio.Handlers.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Api.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : Controller
    {
        /// <summary>
        /// Método "Cadastrar"
        /// </summary>
        /// <param name="command">Command aplica as validações do Flunt caso handler acionar</param>
        /// <param name="handler">Handler retorna o resultado das validações que passaram pelo command</param>
        /// <returns></returns>
        [Route("signup")]
        [HttpPost]
        public GenericCommandResult Signup(CriarContaCommand command,
                                           [FromServices] CriarUsuarioHandle handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Método "Logar"
        /// </summary>
        /// <param name="command">Command aplica as validações do Flunt caso handler acionar</param>
        /// <param name="handler">Handler retorna o resultado das validações que passaram pelo command</param>
        /// <returns></returns>
        [Route("signin")]
        [HttpPost]
        public GenericCommandResult Signin(LogarCommand command,
                                           [FromServices] LogarHandle handler)
        {
            var resultado = (GenericCommandResult)handler.Handle(command);

            if (resultado.Sucesso)
            {
                var token = GenerateJSONWebToken((Usuario)resultado.Data);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            return resultado;
        }

        /// <summary>
        /// Gerador de token
        /// </summary>
        /// <param name="userInfo">Informações do usuario: Nome, Email e Id</param>
        /// <returns></returns>
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaClassificados132"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    "classificado",
                    "classificado",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
