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
      return View(_db.Actors.ToList());
    }

    public ActionResult Details(int id)
    {
      Actor thisActor = _db.Actors
          .Include(actor => actor.JoinEntities)
          .ThenInclude(join => join.Film)
          .FirstOrDefault(actor => actor.ActorId == id);
      return View(thisActor);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Actor actor)
    {
      _db.Actors.Add(actor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Actor thisActor = _db.Actors.FirstOrDefault(actors => actors.ActorId == id);
      return View(thisActor);
    }

    [HttpPost]
    public ActionResult Edit(Actor actor)
    {
      _db.Actors.Update(actor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Actor thisActor = _db.Actors.FirstOrDefault(actors => actors.ActorId == id);
      return View(thisActor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Actor thisActor = _db.Actors.FirstOrDefault(actors => actors.ActorId == id);
      _db.Actors.Remove(thisActor);
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

    public ActionResult AddFilm(int id)
    {
      Actor thisActor = _db.Actors.FirstOrDefault(actors => actors.ActorId == id);
      ViewBag.FilmId = new SelectList(_db.Films, "FilmId", "FilmName");
      return View(thisActor);
    }

    [HttpPost]
    public ActionResult AddFilm(Actor actor, int filmId)
    {
      #nullable enable
      FilmActor? joinEntity = _db.FilmActors.FirstOrDefault(join => (join.FilmId == filmId && join.ActorId == actor.ActorId));
      #nullable disable
      if (joinEntity == null && filmId != 0)
      {
        _db.FilmActors.Add(new FilmActor() { FilmId = filmId, ActorId = actor.ActorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = actor.ActorId });
    }
  }
}
