using Chat.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess;

public class ChatDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<MessageEntity> Messages { get; set; }
    public DbSet<ChatEntity> Chats { get; set; }
    public DbSet<JoiningEntity> Joinings { get; set; }
    public DbSet<AdminEntity> Admins { get; set; }

    public ChatDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<MessageEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<MessageEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<MessageEntity>().HasOne(x => x.Chat)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.ChatId);
        modelBuilder.Entity<MessageEntity>().HasOne(x => x.User)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<ChatEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ChatEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<JoiningEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<JoiningEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<JoiningEntity>().HasOne(x => x.Chat)
            .WithMany(x => x.Joinings)
            .HasForeignKey(x => x.ChatId);
        modelBuilder.Entity<JoiningEntity>().HasOne(x => x.User)
            .WithMany(x => x.Joinings)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();

    }
}