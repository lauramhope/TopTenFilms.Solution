using Microsoft.EntityFrameworkCore;

namespace TopTenFilmList.Models
{
  public class TopTenFilmListContext : DbContext
  {
    public DbSet<Actor> Actors {get;set;}
    public DbSet<Film> Films {get;set;}
    public DbSet<FilmActor> FilmActors{get;set;}

    public DbSet<Studio> Studios {get;set;}

    public TopTenFilmListContext(DbContextOptions options) : base(options) { }
  }
}