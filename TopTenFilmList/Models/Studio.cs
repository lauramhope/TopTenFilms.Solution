using System.Collections.Generic;

namespace TopTenFilmList.Models
{
  public class Studio
  {
    public int StudioId { get; set; }
    public string Name { get; set; }
    public List<Film> Film { get; set; }
  }
}