using Microsoft.EntityFrameworkCore;
using Tweeter.Models;

namespace Tweeter.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Tweet>? Tweets { get; set; }
    public DbSet<Like>? Likes { get; set; }
    public DbSet<Follow>? Follows { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        builder.Entity<Like>()
            .HasIndex(l => new { l.TweetId, l.UserId })
            .IsUnique();

        builder.Entity<Follow>()
            .HasIndex(f => new { f.FolloweeId, f.FollowerId })
            .IsUnique();
    }
}
