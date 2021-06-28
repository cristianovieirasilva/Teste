using Classificados.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Classificados.Dominio.Repositorios
{
    public interface IProdutoRepositorio //Interface com metodos para puxar em handlers e repositorios
    {
        void Adicionar(Produtos produto);
        void Alterar(Produtos produto);
        Produtos BuscarPorTitulo(string titulo = null);
        Produtos BuscarPorId(Guid id);
        IEnumerable<Produtos> Listar();
        void Excluir(Guid id);
    }
}
