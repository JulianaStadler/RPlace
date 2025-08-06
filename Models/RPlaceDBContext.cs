using Microsoft.EntityFrameworkCore;

namespace RPlace.Models;

public class RPlaceDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Player> Player => Set<Player>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<GiftCard> GiftCards => Set<GiftCard>();
    public DbSet<Invite> Invites => Set<Invite>();
    public DbSet<Pixel> Pixels => Set<Pixel>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Player>()
            .HasOne(p => p.Plan)
            .WithMany(p => p.Players)
            .HasForeignKey(p => p.PlanId);

        model.Entity<Player>()
            .HasMany(p => p.RoomPlayers)
            .WithOne(r => r.Player)
            .HasForeignKey(r => r.PlayerId);

        model.Entity<Room>()
            .HasOne(r => r.CreatorPlayer)
            .WithMany()
            .HasForeignKey(r => r.CreatorPlayerId);

        model.Entity<Plan>();

        model.Entity<Permission>();

        model.Entity<GiftCard>();

        model.Entity<Invite>();

        model.Entity<Pixel>();

        model.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.ProfileID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}