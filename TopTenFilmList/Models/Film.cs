using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TopTenFilmList.Models
{
  public class Film
  {
    
    public int FilmId { get; set; }
    public string FilmName { get; set; }
    public float FilmAverageRating {get; set;}
    public string FilmMPARating {get; set;}
    
    public string FilmDescription { get; set; }
    public List<FilmActor> JoinEntities {get;}
    
  }
}