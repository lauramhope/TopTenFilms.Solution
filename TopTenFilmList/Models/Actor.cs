using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TopTenFilmList.Models
{
  public class Actor
  {
    // columns needed for database
    public int ActorId {get; set;}
    public string ActorFName {get; set;}
    public string ActorLName {get; set;}

    public string ActorMainGenre {get; set;}
    public int FilmId { get; set; }
    public List<FilmActor> JoinEntities {get;}
  }
}