using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index(string sortBy)
    {
      List<Animal> model = null;
      if (sortBy == null)
      {
        model = _db.Animals.ToList();
      }
      else if (sortBy.Equals("date"))
      {
        model = _db.Animals.OrderBy(animal => animal.DateOfAdmittance).ToList();
      }
      else if (sortBy.Equals("type"))
      {
        //sort by Type
        model = _db.Animals.OrderBy(animal => animal.Type).ToList();
      }
      return View("Index", model);
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }
  }
}