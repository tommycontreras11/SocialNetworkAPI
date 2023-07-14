using SocialNetworkAPI.Common;

namespace SocialNetworkAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Post> Posts => Set<Post>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>()) 
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Post>()
                .ToTable("Posts");
            #endregion

            #region Properties
            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(60)
                .IsRequired();

           modelBuilder.Entity<User>()
                .Property(u => u.Age)
                .IsRequired();
           #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
