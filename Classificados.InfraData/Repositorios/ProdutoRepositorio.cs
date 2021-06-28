using Classificados.Dominio.Entidades;
using Classificados.Dominio.Repositorios;
using Classificados.InfraData.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Classificados.InfraData.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ClassificadosContext _context;
        public ProdutoRepositorio(ClassificadosContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo para adicionar um produto no banco
        /// </summary>
        /// <param name="produto">dados do produto</param>
        public void Adicionar(Produtos produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
        /// <summary>
        /// Metodo para adicionar um produto no banco
        /// </summary>
        /// <param name="produto">dados do produto</param>
        public void Alterar(Produtos produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }
        /// <summary>
        /// Metodo para buscar produtos
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns>retorna o produto e suas propriedades</returns>
        public Produtos BuscarPorId(Guid id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }
        /// <summary>
        /// Metodo para buscar produtos pelo titulo
        /// </summary>
        /// <param name="titulo">titulo do produto</param>
        /// <returns>retorna o produto e suas propriedades</returns>
        public Produtos BuscarPorTitulo(string titulo)
        {
            return _context.Produtos.FirstOrDefault(p => p.Titulo == titulo);
        }
        /// <summary>
        /// Listagem de produtos 
        /// </summary>
        /// <returns>Produtos ordenados por data de criacao</returns>
        public IEnumerable<Produtos> Listar()
        {
            return _context
                        .Produtos
                        .AsNoTracking()
                        .OrderBy(p => p.DataCriacao);
        }
        /// <summary>
        /// Metodo para excluir produtos
        /// </summary>
        /// <param name="id">id do produto</param>
        public void Excluir(Guid id)
        {
            var produto = BuscarPorId(id);

            _context
                .Produtos
                .Remove(produto);
            _context.SaveChanges();
        }
    }
}
