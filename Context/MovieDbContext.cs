using Microsoft.EntityFrameworkCore;
public class MovieDbContext : DbContext
{

    public DbSet<Movie> Movies {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite("Data source=Movies.db");
}