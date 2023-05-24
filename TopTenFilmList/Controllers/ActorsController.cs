using Microsoft.AspNetCore.Mvc;
using TopTenFilmList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TopTenFilmList.Controllers
{
  public class ActorsController : Controller
  {
    private readonly TopTenFilmListContext _db;

    public ActorsController(TopTenFilmListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }
  }
}