using Classificados.Comum.Commands;
using Classificados.Comum.Queries;
using Classificados.Dominio.Commands.Produto;
using Classificados.Dominio.Handlers.Produto;
using Classificados.Dominio.Handlers.Queries;
using Classificados.Dominio.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Classificados.Api.Controllers
{
    [Route("v1/produto")]
    [ApiController]
    public class ProdutoController : Controller
    {
        /// <summary>
        /// Método de "Cadastrar" produto
        /// </summary>
        /// <param name="command">Command aplica as validações do Flunt caso handler acionar</param>
        /// <param name="handler">Handler retorna o resultado das validações que passaram pelo command</param>
        /// <returns></returns>
        [Route("Cadastrar")]
        [Authorize]
        [HttpPost]
        public GenericCommandResult Create(AdicionarProdutoCommand command,
                                           [FromServices] AdicionarProdutoHandle handler)
        {
            var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );
            command.IdUsuario = new Guid(usuarioid.Value);
            

            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Método para alterar informações do produto
        /// </summary>
        /// <param name="id">Id para localizar o produto</param>
        /// <param name="command">Command aplica as validações do Flunt caso handler acionar</param>
        /// <param name="handler">Handler retorna o resultado das validações que passaram pelo command</param>
        /// <returns></returns>
        [Route("Alterar/{id}")]
        [HttpPut]
        public GenericCommandResult Put(Guid id, EditarProdutoCommand command,
                                        [FromServices] EditarProdutoHandle handler)
        {
            if (id == Guid.Empty)
                return new GenericCommandResult(false, "Informe o Id do Anuncio", "");

            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Método para listar todos os produtos
        /// </summary>
        /// <param name="handle">puxa os itens do command</param>
        /// <returns>Retorna mensagem com listagem</returns>
        [Route("Listar")]
        [HttpGet]
        public GenericQueryResult GetAll([FromServices] ListarProdutoQueryHandle handle)
        {
            ListarProdutoQuery query = new ListarProdutoQuery();

            return (GenericQueryResult)handle.Handle(query);
        }

        /// <summary>
        /// Método que procura um produto por título
        /// </summary>
        /// <param name="handle">Busca o produto e retorna suas informações</param>
        /// <param name="titulo">Título do produto</param>
        /// <returns>Retorna o produto com o título procurado</returns>
        [HttpGet("BuscarTitulo")]
        public GenericQueryResult GetTitle([FromServices] BuscarProdutoQueryHandle handle, string titulo)
        {
            var query = new BuscarProdutoQuery();
            query.Titulo = titulo;

            return (GenericQueryResult)handle.Handle(query);
        }

        /// <summary>
        /// Método para deletar um produto
        /// </summary>
        /// <param name="command">Command valida o ID do produto</param>
        /// <param name="handler">Handler procura no banco o produto</param>
        /// <returns></returns>
        [Route("Deletar")]
        [HttpDelete]
        public GenericCommandResult Delete(ExcluirProdutoCommand command,
                                           [FromServices] ExcluirProdutoHandle handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
