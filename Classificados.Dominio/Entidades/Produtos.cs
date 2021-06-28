using Classificados.Comum.Entidades;
using Flunt.Validations;
using System;

namespace Classificados.Dominio.Entidades
{
    public class Produtos : Entidade //Herança que puxa ID, DataCriacao e DataAlteracao
    {
        public Produtos(string titulo, string descricao, string categoria, string imagem, string preco, string telefone, string cep, Guid idUsuario)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Informe o título do produto")
                .HasMinLen(titulo, 5, "Titulo", "Digite no minímo 5 caracteres")
                .HasMaxLen(titulo, 120, "Titulo", "O título pode ter até 120 caracteres")
                .IsNotNullOrEmpty(descricao, "Descricao", "Por favor, digite uma breve descrição para seu produto")
                .HasMinLen(descricao, 5, "Descricao", "Digite no minímo 5 caracteres")
                .HasMaxLen(descricao, 120, "Descricao", "A descricao pode ter até 120 caracteres")
                .IsNotNullOrEmpty(categoria, "Categoria", "Por favor, informe uma categoria para seu produto")
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe o Imagem do pacote")
                .IsNotNullOrEmpty(preco, "Preco", "Informe um preço para seu produto")
                .IsNotNullOrEmpty(telefone, "Telefone", "Informe um telefone para contato")
                .IsNotNullOrEmpty(cep, "CEP", "Por favor, informe um CEP")
                );

            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                Categoria = categoria;
                Imagem = imagem;
                Preco = preco;
                Telefone = telefone;
                Cep = cep;
                IdUsuario = idUsuario;
            }
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public string Preco { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }

        public Guid IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }


        /// <summary>
        /// Método opcional que atualiza um produto
        /// </summary>
        public void AtualizarProduto(string titulo, string descricao, string categoria, string imagem, string preco, string telefone, string cep)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Informe o título do produto")
                .HasMinLen(titulo, 5, "Titulo", "Digite no minímo 5 caracteres")
                .HasMaxLen(titulo, 120, "Titulo", "O título pode ter até 120 caracteres")
                .IsNotNullOrEmpty(descricao, "Descricao", "Por favor, digite uma breve descrição para seu produto")
                .HasMinLen(descricao, 5, "Descricao", "Digite no minímo 5 caracteres")
                .HasMaxLen(descricao, 120, "Descricao", "A descricao pode ter até 120 caracteres")
                .IsNotNullOrEmpty(categoria, "Categoria", "Por favor, informe uma categoria para seu produto")
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe o Imagem do pacote")
                .IsNotNullOrEmpty(preco, "Preco", "Informe um preço para seu produto")
                .IsNotNullOrEmpty(telefone, "Telefone", "Informe um telefone para contato")
                .IsNotNullOrEmpty(cep, "CEP", "Por favor, informe um CEP")
            );

            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                Categoria = categoria;
                Imagem = imagem;
                Preco = preco;
                Telefone = telefone;
                Cep = cep;
            }
        }
    }
}