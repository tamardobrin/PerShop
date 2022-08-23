using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using WebProject.Repositories;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.MostComented()); 
        }
    }
}
