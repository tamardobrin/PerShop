using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Animal
    {
        [Required(ErrorMessage = "Invalid Id")]
        public int Id { get; set; }

       [Required(ErrorMessage = "Invalid name")]
        public string? Name { get; set; }

      [Required(ErrorMessage = "Invalid Price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Invalid url")]

        [RegularExpression(@"(https?:\/\/.*\.(?:png|jpg))", ErrorMessage = "Invalid url")]
        public string? PictureName { get; set; }

        [Required(ErrorMessage = "Invalid")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Invalid Category")]
       [RegularExpression(@"(?:^|\W)Cats(?:$|\W)|(?:^|\W)Fish(?:$|\W)|(?:^|\W)Rodents(?:$|\W)", ErrorMessage = "Invalid Category")]
        public Category? Category { get; set; }
        public List<Comment>? Comments { get; set; }

    }

}
