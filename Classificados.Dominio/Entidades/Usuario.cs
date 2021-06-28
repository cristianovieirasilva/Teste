using Classificados.Comum.Entidades;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classificados.Dominio.Entidades
{
    public class Usuario : Entidade //Herança que puxa ID, DataCriacao e DataAlteracao
    {
        public Usuario(string nome, string email, string dataNascimento, string senha)
        {
            AddNotifications(new Contract()
                //validação
                .Requires()
                .HasMinLen(nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres")
                .HasMaxLen(nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres")
                .IsEmail(email, "Email", "Informe um e-mail válido")
                .HasMinLen(senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
                DataNascimento = dataNascimento;
                Senha = senha;

            }
        }
        public string Nome { get; set; }        
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Senha { get; set; }
        public List<Produtos> Produtos { get; set; }

        /// <summary>
        /// Método opcional para alterar senha, com validação flunt
        /// </summary>
        public void AlterarSenha(string senha)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
                .HasMaxLen(senha, 12, "Senha", "A senha deve ter no máximo 12 caracteres")
            );

            if (Valid)
                Senha = senha;
        }

        /// <summary>
        /// Método opcional para alterar email, com validação flunt
        /// </summary>
        public void AlterarEmail(string email)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(email, "Email", "Informe um e-mail válido")
            );

            if (Valid)
                Email = email;
        }
    }
}
