using Classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Classificados.Dominio.Commands.Produto
{
    public class AdicionarProdutoCommand : Notifiable, ICommand
    {
        public AdicionarProdutoCommand()
        {}
        public AdicionarProdutoCommand(string titulo, string descricao, string categoria, string imagem, string preco, string telefone, string cep, Guid idUsuario)
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

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public string Preco { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Validação Flunt
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o título do produto")
                .HasMinLen(Titulo, 5, "Titulo", "Digite no minímo 5 caracteres")
                .HasMaxLen(Titulo, 120, "Titulo", "O título pode ter até 120 caracteres")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Por favor, digite uma breve descrição para seu produto")
                .HasMinLen(Descricao, 5, "Descricao", "Digite no minímo 5 caracteres")
                .HasMaxLen(Descricao, 120, "Descricao", "A descricao pode ter até 120 caracteres")
                .IsNotNullOrEmpty(Categoria, "Categoria", "Por favor, informe uma categoria para seu produto")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe o Imagem do pacote")
                .IsNotNullOrEmpty(Preco, "Preco", "Informe um preço para seu produto")
                .IsNotNullOrEmpty(Telefone, "Telefone", "Informe um telefone para contato")
                .IsNotNullOrEmpty(Cep, "CEP", "Por favor, informe um CEP")
                );
        }
    }
}
