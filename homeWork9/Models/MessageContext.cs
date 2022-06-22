using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace homeWork9.Models;

public class MessageContext : DbContext
{
    public DbSet<MessageModel> Messages { get; private set; }
    public DbSet<ContactModel> Contacts { get; private set; }
    public MessageContext(DbContextOptions<MessageContext> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.UseIdentityColumns();
        modelBuilder.HasDefaultSchema("email");
        //messages
        modelBuilder.Entity<MessageModel>().ToTable("Messages").Property(b => b.Id)
            .ValueGeneratedOnAdd();
        //contacts
        modelBuilder.Entity<ContactModel>().ToTable("Contacts").Property(b => b.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ContactModel>().HasIndex(b => b.EmailAddress)
            .IsUnique();

        //messages data
        /*modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 1, FromId = 1, ToId = 1, Theme = "MyTheme", Body = "MyBody", IsHtml = false });
        
        //contacts data
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 1, EmailAddress = "address1@mail.ru" });
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 2, EmailAddress = "address2@mail.ru" });
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 3, EmailAddress = "address3@mail.ru" });
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 4, EmailAddress = "address4@mail.ru" });*/
    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=здесь_указывается_пароль_от_postgres");
    }*/
}