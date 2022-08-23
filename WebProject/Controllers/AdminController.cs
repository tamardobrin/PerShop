using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using WebProject.Repositories;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _repository;
        public AdminController(IRepository repository)
        {
            _repository = repository;
        }
      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _repository.GetCategories();
            return View(_repository.GetAnimals().First(animal => animal.Id == id));
        }
        [HttpPost]
        public IActionResult Edit(Animal animal, int categoryId)
        {
            if (ModelState.IsValid)
            {
                _repository.EditAnimal(animal);
                return RedirectToAction("SomeAction", "Validation");
            }
            else
            {
                animal.Category = _repository.GetCategories().First(category => category.Id == categoryId);
                _repository.EditAnimal(animal);
            }

            return RedirectToAction("SomeAction", "Validation");
        }
        public IActionResult Delete(int id)
        {
            _repository.DeleteAnimal(id);
            return RedirectToAction("SomeAction", "Validation");
        }
        public IActionResult AddAnimalPage()
        {
            List<Comment> demoComList = new();
            ViewBag.currentAnimalId = _repository.CurrentId();
            ViewBag.demoComnentsList = demoComList;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Animal animal, int categoryId)
        {
            if (ModelState.IsValid)
            {
                _repository.EditAnimal(animal);
                return RedirectToAction("SomeAction", "Validation");
            }
            else
            {
                animal.Category = _repository.GetCategories().First(category => category.Id == categoryId);
                _repository.AddAnimal(animal);
            }
            return RedirectToAction("SomeAction", "Validation");
        }

    }
}
