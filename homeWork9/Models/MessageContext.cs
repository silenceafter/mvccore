using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace homeWork9.Models;

public class MessageContext : DbContext
{
    public DbSet<MessageModel> Messages { get; private set; }
    public DbSet<ContactModel> Contacts { get; private set; }
    public DbSet<MessageTypeModel> MessageTypes { get; private set; }
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
        //messagetypes
        modelBuilder.Entity<MessageTypeModel>().ToTable("MessageTypes").Property(b => b.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ContactModel>().HasIndex(b => b.EmailAddress)
            .IsUnique();
        modelBuilder.Entity<MessageTypeModel>().HasIndex(b => b.Name)
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

        //messages data
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 1, FromId = 1, ToId = 2, Theme = "Theme1", 
                Body = "Body1", IsHtml = false, TypeId = 1 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 2, FromId = 3, ToId = 1, Theme = "Theme2", 
                Body = "Body2", IsHtml = false, TypeId = 2 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 3, FromId = 2, ToId = 3, Theme = "Theme3", 
                Body = "Body3", IsHtml = false, TypeId = 1 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 4, FromId = 4, ToId = 2, Theme = "Theme4", 
                Body = "Body4", IsHtml = false, TypeId = 2 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 5, FromId = 3, ToId = 1, Theme = "Theme5", 
                Body = "Body5", IsHtml = false, TypeId = 1 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 6, FromId = 5, ToId = 3, Theme = "Theme6", 
                Body = "Body6", IsHtml = false, TypeId = 2 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 7, FromId = 4, ToId = 2, Theme = "Theme7", 
                Body = "Body7", IsHtml = false, TypeId = 1 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 8, FromId = 3, ToId = 4, Theme = "Theme8", 
                Body = "Body8", IsHtml = false, TypeId = 2 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 9, FromId = 5, ToId = 1, Theme = "Theme9", 
                Body = "Body9", IsHtml = false, TypeId = 1 });
        modelBuilder.Entity<MessageModel>().HasData(
            new MessageModel() { Id = 10, FromId = 5, ToId = 5, Theme = "Theme10",
                Body = "Body10", IsHtml = false, TypeId = 2 });

        //messagetypes data
        modelBuilder.Entity<MessageTypeModel>().HasData(
            new MessageTypeModel() { Id = 1, Name = "Incoming" });
        modelBuilder.Entity<MessageTypeModel>().HasData(
            new MessageTypeModel() { Id = 2, Name = "Outgoing" });        
    }
}