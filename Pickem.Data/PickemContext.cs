using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pickem.Domain;

namespace Pickem.Data
{
    public class PickemContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLeague> UserLeagues { get; set; }
        public DbSet<UserLeagueSchedule> UserLeagueSchedules { get; set; }
        public DbSet<UserLeagueScheduleUserPicks> UserLeagueScheduleUserPicks { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGroup> GameGroups { get; set; }
        public DbSet<SportLeague>SportLeagues { get; set; }
        

        public PickemContext(DbContextOptions<PickemContext> options): base(options)
        {
            //Disable Tracking
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public PickemContext(): base()
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLeague>().HasKey(s => new { s.UserId, s.LeagueId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PickemConnex"));
        }
    }
}
