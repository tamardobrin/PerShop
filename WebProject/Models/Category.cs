namespace WebProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
         public ICollection<Animal>? AnimalsPC { get; set; }
    }
}
