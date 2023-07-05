
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;
using WebApiEntityFramework.Entities;
using WebApiEntityFramework.Events.ChangeTracker;
using WebApiEntityFramework.KeyLessEntities;
using WebApiEntityFramework.Seeding;
using WebApiEntityFramework.Services.User;

namespace WebApiEntityFramework.Data
{
    public class ApplicationDbContext:DbContext
    {
        private readonly IUser _user;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUser user, IChangeTrackerEvent changeTrackerEvent) : base(options)
        {
            _user = user;
            ChangeTracker.Tracked += changeTrackerEvent.Tracked;
            ChangeTracker.StateChanged += changeTrackerEvent.StateChanged;
            SavedChanges += changeTrackerEvent.SavedChanges;
            SaveChangesFailed += changeTrackerEvent.SaveChangesFailed;
            SavingChanges += changeTrackerEvent.SavingChanges;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            ModelSeeder.Seed(builder);
            
            //builder.Ignore<Address>();

            foreach (var entity in builder.Model.GetEntityTypes())
                foreach (var prop in entity.GetProperties())
                    if (prop.ClrType == typeof(string) && prop.Name.Contains("link", StringComparison.CurrentCultureIgnoreCase))
                        prop.SetIsUnicode(false);

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2"); //it's already the default type
            //configurationBuilder.Properties<decimal>().HavePrecision(9, 2);
            //configurationBuilder.Properties<string>().HaveMaxLength(500);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Default",builder=>builder.UseNetTopologySuite());
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().Where(e=>e.State == EntityState.Added))
            { 
                entry.Entity.CreatedBy = _user.Id;
                entry.Entity.ModifiedBy = _user.Id;
            }

            foreach(var entry in ChangeTracker.Entries<AuditableEntity>().Where(e=>e.State == EntityState.Modified))
            {
                entry.Entity.ModifiedBy = _user.Id;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CinemaWithoutLocation> CinemaWithoutLocations { get; set; }
        public DbSet<MoviesWithCount> MoviesWithCounts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CinemaDetail> CinemaDetails { get; set; }
    }
}
