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

        //contacts data
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 1, EmailAddress = "a59-info@yandex.ru" });
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 2, EmailAddress = "silenceafter@yandex.ru" });
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 3, EmailAddress = "axasthur89@mail.ru" });
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 4, EmailAddress = "a8959@mail.ru" });
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactModel() { Id = 5, EmailAddress = "a25031992@gmail.com" });
    }
}