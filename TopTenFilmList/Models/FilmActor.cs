using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TopTenFilmList.Models
{
  public class FilmActor
  {

    public int FilmActorId { get; set; }

    public int FilmId { get; set; }
    public Film Film { get; set; }
    
    public int ActorId { get; set; }
    public Actor Actor { get; set; }
    
  }
}