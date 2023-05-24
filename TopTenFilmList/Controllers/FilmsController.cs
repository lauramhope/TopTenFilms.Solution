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
      return View(_db.Films.ToList());
    }

    public ActionResult Details(int id)
    {
      Film thisFilm = _db.Films
          .Include(film => film.JoinEntities)
          .ThenInclude(join => join.Actor)
          .FirstOrDefault(film => film.FilmId == id);
      return View(thisFilm);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Film film)
    {
      _db.Films.Add(film);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Film thisFilm = _db.Films.FirstOrDefault(films => films.FilmId == id);
      return View(thisFilm);
    }

    [HttpPost]
    public ActionResult Edit(Film film)
    {
      _db.Films.Update(film);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Film thisFilm = _db.Films.FirstOrDefault(films => films.FilmId == id);
      return View(thisFilm);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Film thisFilm = _db.Films.FirstOrDefault(films => films.FilmId == id);
      _db.Films.Remove(thisFilm);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      FilmActor joinEntry = _db.FilmActors.FirstOrDefault(entry => entry.FilmActorId == joinId);
      _db.FilmActors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddActor(int id)
    {
      Film thisFilm = _db.Films.FirstOrDefault(films => films.FilmId == id);
      ViewBag.ActorId = new SelectList(_db.Actors, "ActorId", "ActorLName");
      return View(thisFilm);
    }

    [HttpPost]
    public ActionResult AddActor(Film film, int actorId)
    {
      #nullable enable
      FilmActor? joinEntity = _db.FilmActors.FirstOrDefault(join => (join.ActorId == actorId && join.FilmId == film.FilmId));
      #nullable disable
      if (joinEntity == null && actorId != 0)
      {
        _db.FilmActors.Add(new FilmActor() { ActorId = actorId, FilmId = film.FilmId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = film.FilmId });
    }
  }
}
