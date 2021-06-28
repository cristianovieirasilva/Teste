using Classificados.Comum.Queries;
using System;

namespace Classificados.Dominio.Queries
{
    public class BuscarProdutoQuery : IQuery
    {
        public void Validar()
        {}
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public string Preco { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public Guid IdUsuario { get; set; }
    }
       
    public class BuscarProdutoQueryResult
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public string Preco { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public Guid IdUsuario { get; set; }
    }

}
