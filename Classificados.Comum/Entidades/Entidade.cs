using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classificados.Comum.Entidades
{
    public class Entidade : Notifiable //Notifiable faz parte do pacote "Flunt" que gerencia as validações
    {
        /// <summary>
        /// Classe criada a fim de utilizar a abstração, todas que herdarem terão as propriedades Id, DataCriacao e DataAlteracao
        /// </summary>
        public Entidade()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
