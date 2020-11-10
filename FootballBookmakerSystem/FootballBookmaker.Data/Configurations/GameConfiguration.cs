
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FootballBookmaker.Models;

namespace FootballBookmaker.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> game)
        {
            game
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId);

            game
               .HasOne(g => g.AwayTeam)
               .WithMany(t => t.AwayGames)
               .HasForeignKey(g => g.AwayTeamId);
        }
    }
}
