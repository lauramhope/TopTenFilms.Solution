using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TopTenFilmList.Models
{
  public class Film
  {
    
    public int FilmId { get; set; }
    [Required(ErrorMessage = "Film name can't be left empty")]
    public string FilmName { get; set; }
    public int FilmAverageRating {get; set;}
    public string FilmMPARating {get; set;}
    
    public string FilmDescription { get; set; }
    public List<FilmActor> JoinEntities {get;}
    
  }
}