using Microsoft.EntityFrameworkCore;

namespace projetoProva.Models
{
    public partial class BDContexto : DbContext
    {
        public BDContexto()
        {
        }

        public BDContexto(DbContextOptions<BDContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Videogame> Videogames { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = WebApplication.CreateBuilder();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.24-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Videogame>(entity =>
            {
                entity.ToTable("videogame");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ano)
                    .HasColumnType("year")
                    .HasColumnName("ano");

                entity.Property(e => e.Fabricante)
                    .HasMaxLength(100)
                    .HasColumnName("fabricante");

                entity.Property(e => e.Geracao).HasColumnName("geracao");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
