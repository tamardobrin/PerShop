using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Repositories
{
    public class MyRepository : IRepository
    {
        private AnimalContext _context;
        public MyRepository(AnimalContext context)
        {
            _context = context;
        }
        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals!.Include(c=>c.Comments);
        }
        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments!;
        }
        public Animal GetAnimal(int animalID)
        {
            return _context.Animals!.First(animal => animal.Id == animalID);
        }

        public void AddAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }
      

        public void DeleteAnimal(int id)
        {
            var animal = _context.Animals!.Single(m => m.Id == id);
            _context.Animals!.Remove(animal);
           _context.SaveChanges();
        }

        public void EditAnimal(Animal animal)
        {
            var originAnimal= _context.Animals!.SingleOrDefault(a => a.Id == animal.Id);
            originAnimal.Name= animal.Name;
            originAnimal.Price = animal.Price;
            originAnimal.PictureName = animal.PictureName;
            originAnimal.Description = animal.Description;
            originAnimal.Category = animal.Category;
            _context.SaveChanges();
            
        }

        public IEnumerable<Animal> GetAnimalsByCategory(Category category)
        {
            return _context.Animals!.Where(animal => animal.Category==category).ToList();
        }

        public List<Animal> MostComented()
        {
            var animal = _context.Animals!.Include(c => c.Comments);
            var pets = animal!.OrderByDescending(p => p.Comments!.Count).Take(2).ToList();
            return pets;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories!;
        }

        public int CurrentId()
        {
            int lastAnimalId = _context.Animals!.Max(item => item.Id);
            int CurrentAnimalId = lastAnimalId + 1;
            return CurrentAnimalId;
        }

       

        public int CurrentCommentId()
        {
            int lastCommentId = _context.Comments!.Max(item => item.Id);
            int CurrentCommentId = lastCommentId + 1;
            return CurrentCommentId;
        }

        public void SaveComment(Comment comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }

       
    }
}
