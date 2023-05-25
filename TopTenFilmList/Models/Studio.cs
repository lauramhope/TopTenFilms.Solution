using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopTenFilmList.Models
{
  public class Studio
  {
    
    public int StudioId { get; set; }
    [Required(ErrorMessage = "Name can not be empty")]
    public string Name { get; set; }
    public List<Film> Films { get; set; }
  }
}