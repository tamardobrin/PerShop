namespace WebProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Animal? Animal { get; set; }
        public int AnimalId { get; set; }
        public string? Content { get; set; }

    }
}
