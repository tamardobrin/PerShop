using WebProject.Models;

namespace WebProject.Repositories
{
    public interface ICommentsRepository
    {
        IEnumerable<Comment> GetCommentsByAnimalID(int AnimalID);
    }
}
