using Classificados.Dominio.Entidades;
using Classificados.Dominio.Repositorios;
using Classificados.InfraData.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classificados.InfraData.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ClassificadosContext _context;
        public UsuarioRepositorio(ClassificadosContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo para adicionar um produto no banco
        /// </summary>
        /// <param name="usuario">dados do produto</param>
        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo para alterar um usuario no banco
        /// </summary>
        /// <param name="usuario">dados do usuario</param>
        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }
        /// <summary>
        /// Metodo para buscar um usuario por email
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <returns>retorna o usuario e suas informacoes</returns>
        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }
        /// <summary>
        /// Metodo para buscar usuarios por id
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>retorna o usuario e suas informacoes</returns>
        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }
        /// <summary>
        /// Metodo para listar usuarios 
        /// </summary>
        /// <returns>retorna usuarios por ordem de criacao</returns>
        public ICollection<Usuario> Listar()
        {
            return _context.Usuarios
                .AsNoTracking()
                .OrderBy(u => u.DataCriacao)
                .ToList();
        }
    }
}
