using Classificados.Comum.Commands;
using System;

namespace Classificados.Dominio.Commands.Produto
{
    public class ExcluirProdutoCommand : ICommand
    {
        public Guid Id { get; set; }
        public void Validar() { }
    }
}