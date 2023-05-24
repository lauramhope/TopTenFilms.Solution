using Microsoft.AspNetCore.Mvc;
using TopTenFilmList.Models;
using System.Collections.Generic;
using System.Linq;

namespace TopTenFilmList.Controllers
{
    public class HomeController : Controller
    {
      private readonly TopTenFilmListContext _db;

      public HomeController(TopTenFilmListContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        Film[] films = _db.Films.ToArray();
        Actor[] actors = _db.Actors.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("films", films);
        model.Add("actors", actors);
        return View(model);
      }
    }
}