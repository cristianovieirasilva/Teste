using Classificados.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Classificados.Dominio.Repositorios 
{
    public interface IUsuarioRepositorio //Interface com metodos para puxar em handlers e repositorios
    {
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);
        ICollection<Usuario> Listar();
    }
}
