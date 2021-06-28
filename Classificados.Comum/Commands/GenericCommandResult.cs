using System;
using System.Collections.Generic;
using System.Text;

namespace Classificados.Comum.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        /// <summary>
        /// Mensagem padrão como retorno para o usuário
        /// </summary>
        /// <param name="sucesso">indica se funcionou ou deu erro</param>
        /// <param name="mensagem">retorna a mensagem do sucesso ou erro</param>
        /// <param name="data">retorna os objetos</param>
        public GenericCommandResult(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public object Data { get; private set; }
    }
}
