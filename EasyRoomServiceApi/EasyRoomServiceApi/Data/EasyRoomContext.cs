using EasyRoomServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyRoomServiceApi.Data
{
    public class EasyRoomContext : DbContext
    {
        public EasyRoomContext(DbContextOptions<EasyRoomContext> options) : base(options)
        {

        }

        //Database Models   be awair to set the procidure of creating database
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        //On Model Creating 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //initailze the relationship between friend class model and user class model
            modelBuilder.Entity<Friend>()
                .HasOne(u => u.User)
                .WithMany(f => f.Friends)
                .HasForeignKey(u => u.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            //initailze the relationship between Message class model and user class model
            modelBuilder.Entity<Message>()
                .HasOne(u => u.From)
                .WithMany(f => f.Messages)
                .HasForeignKey(u => u.FromID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
