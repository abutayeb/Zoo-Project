using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class Animal1Controller : Controller
    {
        AnimalService service = new AnimalService();
        // GET: Animal1
        public ActionResult Index()
        {
            
            var viewAnimals = service.GetAnimals();
            return View(viewAnimals);
        }

        public ActionResult Details(int id)
        {
         ViewAnimal animal=service.GetAnimal(id);
            return View(animal);
        }

        //create page start
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            //save
            bool saved=service.Save(animal);
            return RedirectToAction("Index");
        }
        //end///


        //Edit page start
        [HttpGet]
        public ActionResult Edit(int Id)
        {
           Animal animal=service.GetDbAnimal(Id);
            return View(animal);
        }

        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            //save
            bool saved = service.Update(animal);
            return RedirectToAction("Index");
        }
        //end//

        //Delete page start
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            //save
            bool saved = service.Delete(animal);
            return RedirectToAction("Index");
        }
        //end///
    }
}