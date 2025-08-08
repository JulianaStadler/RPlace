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
            .HasForeignKey(p => p.PlanId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<RoomPlayer>()
            .HasOne(r => r.Room)
            .WithMany(r => r.RoomPlayers)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<RoomPlayer>()
            .HasOne(r => r.Player)
            .WithMany(r => r.RoomPlayers)
            .HasForeignKey(r => r.PlayerId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<RoomPlayer>()
            .HasOne(r => r.Permission)
            .WithMany(p => p.RoomPlayers)
            .HasForeignKey(r => r.PermissionId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<GiftCard>()
            .HasOne(g => g.Plan)
            .WithMany(p => p.GiftCards)
            .HasForeignKey(g => g.PlanId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Invite>()
            .HasOne(i => i.Player)
            .WithMany()
            .HasForeignKey(i => i.PlayerId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Invite>()
            .HasOne(i => i.Room)
            .WithMany()
            .HasForeignKey(i => i.RoomId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Pixel>()
            .HasOne(p => p.Room)
            .WithMany(r => r.Pixels)
            .HasForeignKey(p => p.RoomId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}