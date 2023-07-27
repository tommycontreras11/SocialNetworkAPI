using SocialNetworkAPI.Common;

namespace SocialNetworkAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();

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

            modelBuilder.Entity<Comment>()
                .ToTable("Comments");
            #endregion

            #region Properties

            #region User
            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(u => u.Gender)
                 .IsRequired();
            #endregion

            #region Post
            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(p => p.Description)
                .HasMaxLength(500);
            #endregion

            #region Comment
            modelBuilder.Entity<Comment>()
                .Property(c => c.Description)
                .HasMaxLength(500)
                .IsRequired();
            #endregion

            #endregion

            #region Relationships
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .IsRequired();
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
