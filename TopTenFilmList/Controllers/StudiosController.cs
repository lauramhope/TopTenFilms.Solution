using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TopTenFilmList.Models;
using System.Collections.Generic;
using System.Linq;

namespace TopTenFilmList.Controllers
{
  public class StudiosController : Controller
  {
    private readonly TopTenFilmListContext _db;

    public StudiosController(TopTenFilmListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Studio> model = _db.Studios.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Studio studio)
    {
      if(!ModelState.IsValid)
      {
        return View(studio);
      }
      else
      {
        _db.Studios.Add(studio);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Studio thisStudio = _db.Studios
                                .Include(studio => studio.Films)
                                .ThenInclude(film => film.JoinEntities)
                                .ThenInclude(join => join.Actor)
                                .FirstOrDefault(studio => studio.StudioId == id);
      return View(thisStudio);
    }

    public ActionResult Edit(int id)
    {
      Studio thisStudio = _db.Studios.FirstOrDefault(studio => studio.StudioId == id);
      return View(thisStudio);
    }

    [HttpPost]
    public ActionResult Edit(Studio studio)
    {
      if(!ModelState.IsValid)
      {
        return View(studio);
      }
      else
      {
        _db.Studios.Update(studio);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Delete(int id)
    {
      Studio thisStudio = _db.Studios.FirstOrDefault(studio => studio.StudioId == id);
      return View(thisStudio);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Studio thisStudio = _db.Studios.FirstOrDefault(studio => studio.StudioId == id);
      _db.Studios.Remove(thisStudio);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
