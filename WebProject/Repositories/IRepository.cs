using WebProject.Models;

namespace WebProject.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animal> GetAnimals();
        IEnumerable<Comment> GetComments();
        IEnumerable<Category> GetCategories();
        IEnumerable<Animal> GetAnimalsByCategory(Category category);
        void AddAnimal(Animal animal);
        void EditAnimal(Animal animal);
        void DeleteAnimal(int id);
        void SaveComment(Comment comment);

        int CurrentId();
        int CurrentCommentId();
        Animal GetAnimal(int animalID);
        List<Animal> MostComented();
    }
}
