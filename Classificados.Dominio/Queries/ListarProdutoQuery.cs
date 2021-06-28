using Classificados.Comum.Queries;
using Classificados.Dominio.Entidades;
using System;

namespace Classificados.Dominio.Queries
{
    public class ListarProdutoQuery : IQuery
   {
       public void Validar()
        {}
    }

    public class ListarQueryResult
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public string Preco { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public Guid IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
