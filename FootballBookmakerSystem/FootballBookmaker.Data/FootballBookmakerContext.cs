
using Microsoft.EntityFrameworkCore;

using FootballBookmaker.Models;
using FootballBookmaker.Data.Settings;
using System.Reflection;

namespace FootballBookmaker.Data
{
    public class FootballBookmakerContext : DbContext
    {
        public FootballBookmakerContext()
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseSqlServer(ConnectionSettings.DEFAULT_CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
