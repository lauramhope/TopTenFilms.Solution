using Microsoft.AspNetCore.Mvc;
using TopTenFilmList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TopTenFilmList.Controllers
{
  public class FilmsController : Controller
  {
    private readonly TopTenFilmListContext _db;

    public FilmsController(TopTenFilmListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }
  }
}