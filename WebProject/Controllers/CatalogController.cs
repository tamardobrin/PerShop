using Microsoft.AspNetCore.Mvc;
using System;
using WebProject.Models;
using WebProject.Repositories;

namespace WebProject.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository _repository;
        public CatalogController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult CatalogPage(int categoryId)
        {
            if (categoryId==0) 
            return View(_repository.GetAnimals());
            else
                return View(_repository.GetAnimalsByCategory(_repository.GetCategories().First(category => category.Id == categoryId)));
        }
        public IActionResult AnimalPage(int Id)
        {
            Random rnd = new Random();
            int num = rnd.Next(10, 50);
            ViewBag.random = num;
            return View(_repository.GetAnimals().First(animal => animal.Id==Id));
        }
        [HttpPost]
        public IActionResult AddComment(int AnimalId, string CommentMessage)
        {
            var animal = _repository.GetAnimals().First(an => an.Id == AnimalId);
            Comment comment = new() { Id = _repository.CurrentCommentId(), AnimalId = AnimalId, Content = CommentMessage };
            animal.Comments!.Add(comment);
            _repository.SaveComment(comment);
            ViewBag.newComment = CommentMessage;
            return RedirectToAction("AnimalPage", new { Id = AnimalId });
        }
    }
}
