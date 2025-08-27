using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RPlace.Models;

public class RPlaceDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Player> Player => Set<Player>();
    public DbSet<Room> Room => Set<Room>();
    public DbSet<RoomPlayer> RoomPlayer => Set<RoomPlayer>();
    public DbSet<Plan> Plan => Set<Plan>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<GiftCard> GiftCard => Set<GiftCard>();
    public DbSet<Invite> Invite => Set<Invite>();
    public DbSet<Pixel> Pixel => Set<Pixel>();

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

public class RPlaceDbContextFactory : IDesignTimeDbContextFactory<RPlaceDbContext>
{
    public RPlaceDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<RPlaceDbContext>();
        var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
        options.UseSqlServer(sqlConn);
        return new RPlaceDbContext(options.Options);
    }
}
