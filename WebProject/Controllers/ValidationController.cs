using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using WebProject.Repositories;

namespace WebProject.Controllers
{
    public class ValidationController : Controller
    {
        private IRepository _repository;
        public ValidationController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ValidationAction()
        {
            return View();
        }
        public IActionResult ValidationForForm(Person person)
        {
            if (ModelState.IsValid)
            {
                if (person.Password == "tamarAdmin" && person.Email == "tamardobrin@gmail.com")
                    return RedirectToAction("SomeAction");
                else
                    return Content("not a valid admin");
            }
            return RedirectToAction("SomeAction");

        }
        public IActionResult SomeAction(int Id)
        {
            if (Id == 0)
                return View(_repository.GetAnimals());
            else
                return View(_repository.GetAnimalsByCategory(_repository.GetCategories().First(category => category.Id == Id)));
        }
        public IActionResult FilterForAdminPage(int categoryId)
        {
            if (categoryId == 0)
                return RedirectToAction("SomeAction", new { Id = categoryId });
            else
                return RedirectToAction("SomeAction", new { Id = categoryId });
        }
    }
}
