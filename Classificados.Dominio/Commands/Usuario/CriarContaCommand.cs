using Classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Classificados.Dominio.Commands.Usuario
{
    public class CriarContaCommand : Notifiable, ICommand
    {
        public CriarContaCommand()
        {}
        public CriarContaCommand(string nome, string email, string dataNascimento, string senha)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Senha = senha;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Senha { get; set; }

        /// <summary>
        /// Validação flunt
        /// </summary>
        public void Validar()
        {
            AddNotifications(new Contract()
                   .Requires()
                   .HasMinLen(Nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres")
                   .HasMaxLen(Nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres")
                   .IsEmail(Email, "Email", "Informe um e-mail válido")
                   .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
                   .HasMaxLen(Senha, 12, "Senha", "A senha deve ter no máximo 12 caracteres")
               );
        }
    }
}
