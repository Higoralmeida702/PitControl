using Microsoft.EntityFrameworkCore;
using PitControl.Domain.Model;

namespace PitControl.Infra.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoEmEstoque> ProdutosEmEstoque { get; set; }
        public DbSet<SetorEstoque> SetoresEstoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Fornecedor)        
                .WithMany()                  
                .HasForeignKey(p => p.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdutoEmEstoque>()
                .HasOne(pe => pe.Produto)
                .WithMany()
                .HasForeignKey(pe => pe.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProdutoEmEstoque>()
                .HasOne(pe => pe.SetorEstoque)
                .WithMany(se => se.ProdutosEmEstoque)
                .HasForeignKey(pe => pe.SetorEstoqueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.Cnpj)
                .HasMaxLength(18);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Codigo)
                .HasMaxLength(20);
        }
    }
}