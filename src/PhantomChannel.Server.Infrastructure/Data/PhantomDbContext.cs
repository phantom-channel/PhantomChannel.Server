using Microsoft.EntityFrameworkCore;
using PhantomChannel.Server.Domain.Entities;

namespace PhantomChannel.Server.Infrastructure.Data;

public class PhantomDbContext(DbContextOptions<PhantomDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> User { get; set; }
    public DbSet<CommentEntity> Comment { get; set; }
    public DbSet<DictionaryEntity> Dictionary { get; set; }
    public DbSet<LikeItEntity> LikeIt { get; set; }
    public DbSet<MenuEntity> Menu { get; set; }
    public DbSet<MessageEntity> Message { get; set; }
    public DbSet<QueryEntity> Query { get; set; }
    public DbSet<PostEntity> Post { get; set; }
    public DbSet<RoomEntity> Room { get; set; }
    public DbSet<RoleEntity> Role { get; set; }
    public DbSet<SectionEntity> Section { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<UserEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<CommentEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<DictionaryEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<LikeItEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<MenuEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<MessageEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<QueryEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<PostEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<RoomEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<RoleEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);
        modelBuilder.Entity<SectionEntity>().Property(e => e.Id).HasIdentityOptions(startValue: 10000);


    }
    public override int SaveChanges()
    {
        InitTimeProperty();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        InitTimeProperty();
        return base.SaveChangesAsync(cancellationToken);
    }
    private void InitTimeProperty()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreateTime = DateTime.UtcNow;
            }
            entity.UpdateTime = DateTime.UtcNow;
        }
    }

}
