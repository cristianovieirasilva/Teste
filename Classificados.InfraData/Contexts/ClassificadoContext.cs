using Classificados.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Classificados.InfraData.Contexts
{
    public class ClassificadosContext : DbContext
    {
        public ClassificadosContext(DbContextOptions<ClassificadosContext> options) : base(options)
        { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            #region Usuario
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();
            //Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();
            //Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
            //Data de Nascimento
            modelBuilder.Entity<Usuario>().Property(x => x.DataNascimento).HasColumnType("varchar(8)");
            //Datas
            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(x => x.DataAlteracao).HasColumnType("DateTime");
            //Relacionamento Um para Muitos - Usuário e Produtos
            modelBuilder.Entity<Usuario>()
                                .HasMany(c => c.Produtos)
                                .WithOne(u => u.Usuario)
                                .HasForeignKey(fk => fk.IdUsuario);
            #endregion

            #region Produto
            modelBuilder.Entity<Produtos>().ToTable("Produtos");
            modelBuilder.Entity<Produtos>().Property(x => x.Id);
            //Titulo
            modelBuilder.Entity<Produtos>().Property(x => x.Titulo).HasMaxLength(120);
            modelBuilder.Entity<Produtos>().Property(x => x.Titulo).HasColumnType("varchar(120)");
            modelBuilder.Entity<Produtos>().Property(x => x.Titulo).IsRequired();
            //Descricao
            modelBuilder.Entity<Produtos>().Property(x => x.Descricao).HasColumnType("Text");
            modelBuilder.Entity<Produtos>().Property(x => x.Descricao).IsRequired();
            //Categoria
            modelBuilder.Entity<Produtos>().Property(x => x.Descricao).HasColumnType("Text");
            modelBuilder.Entity<Produtos>().Property(x => x.Descricao).IsRequired();
            //Imagem
            modelBuilder.Entity<Produtos>().Property(x => x.Imagem).HasMaxLength(250);
            modelBuilder.Entity<Produtos>().Property(x => x.Imagem).HasColumnType("varchar(350)");
            modelBuilder.Entity<Produtos>().Property(x => x.Imagem).IsRequired();
            //Preco
            modelBuilder.Entity<Produtos>().Property(x => x.Preco).HasMaxLength(6);
            modelBuilder.Entity<Produtos>().Property(x => x.Preco).HasColumnType("varchar(6)");
            modelBuilder.Entity<Produtos>().Property(x => x.Preco).IsRequired();
            //Telefone
            modelBuilder.Entity<Produtos>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Produtos>().Property(x => x.Telefone).HasColumnType("varchar(11)");
            //CEP
            modelBuilder.Entity<Produtos>().Property(x => x.Cep).HasMaxLength(8);
            modelBuilder.Entity<Produtos>().Property(x => x.Cep).HasColumnType("varchar(8)");
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
