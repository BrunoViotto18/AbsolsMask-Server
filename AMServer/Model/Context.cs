using Microsoft.EntityFrameworkCore;
namespace Model;

public class Context : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Itens> Itens { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<ItensColetados> ItensColetados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:absolsmask.database.windows.net,1433;Initial Catalog=AbsolsMask;Persist Security Info=False;User ID=brunao;Password=Pokemonavg123*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.id);
            entity.Property(u => u.login);
            entity.Property(u => u.password);
        });
        modelBuilder.Entity<Itens>(entity =>
        {
            entity.HasKey(i => i.id);
            entity.Property(i => i.name);
        });
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(g => g.id);
            entity.Property(g => g.date);
            entity.Property(g => g.seed);
            entity.Property(g => g.sala_X);
            entity.Property(g => g.sala_Y);
            entity.Property(g => g.porta);
            entity.HasOne(g => g.user);
        });
        modelBuilder.Entity<ItensColetados>(entity =>
        {
            entity.HasKey(it => it.id);
            entity.HasOne(it => it.game);
            entity.HasOne(it => it.itens);
        });
    }
}