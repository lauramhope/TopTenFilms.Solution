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
        return View();
      }
    }
}