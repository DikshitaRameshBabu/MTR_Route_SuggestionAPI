using Microsoft.EntityFrameworkCore;
using MTR_RouteSuggestionAPI.Models;

namespace MTR_RouteSuggestionAPI.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<RouteSuggestion> RouteSuggestions { get; set; }

        public DbSet<SearchHistory> SearchHistories { get; set; }

    }
}
