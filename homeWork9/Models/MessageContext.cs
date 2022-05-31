using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace homeWork9.Models;

public class MessageContext : DbContext
{
    public DbSet<MessageModel> Messages { get; private set; }
    public MessageContext(DbContextOptions<MessageContext> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.UseIdentityColumns();
        modelBuilder.HasDefaultSchema("email");
        modelBuilder.Entity<MessageModel>().ToTable("Messages").Property(b => b.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 1, FromId = 1, ToId = 1, Theme = "MyTheme", Body = "MyBody", IsHtml = false }
        );
    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=здесь_указывается_пароль_от_postgres");
    }*/
}