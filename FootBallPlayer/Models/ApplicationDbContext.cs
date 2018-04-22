using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FootBallPlayer.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Vister> Visters { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Massege> Masseges { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Imag> Imags { get; set; }
        public DbSet<Video> Videos { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Article>()

                .HasRequired(x => x.Player)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}