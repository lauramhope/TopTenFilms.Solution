using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TopTenFilmList.Models
{
  public class Actor
  {
    // columns needed for database
    public int ActorId {get; set;}
    [Required(ErrorMessage = "Actor First name can't be left empty")]
    public string ActorFName {get; set;}
    [Required(ErrorMessage = "Actor Last name can't be left empty")]
    public string ActorLName {get; set;}

    public string ActorMainGenre {get; set;}
    public int FilmId { get; set; }
    public List<FilmActor> JoinEntities {get;}
  }
}