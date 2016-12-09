using Microsoft.EntityFrameworkCore;
using MyFirstCoreApp.Models;

namespace MyFirstCoreApp.Data
{
    public class RewardingContext : DbContext
    {
        public RewardingContext(DbContextOptions<RewardingContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Rewarding> Rewardings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>().ToTable("Award");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Rewarding>().ToTable("Rewarding");
            modelBuilder.Entity<Rewarding>().HasKey(t => new { t.UserID, t.AwardID });
        }
    }
}
