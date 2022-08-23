using Microsoft.EntityFrameworkCore;
using WebProject.Models;

namespace WebProject.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {

        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Cats"},
                new { Id = 2, Name = "Fish"},
                new { Id = 3, Name = "Rodents"}
            );

            modelBuilder.Entity<Animal>().HasData(
               new { Id = 1, Name = "Sphynx", Price=3000, PictureName= "https://i.pinimg.com/564x/cb/b4/c3/cbb4c3585048e06cb3b49ccb30e4343d.jpg", Description= "The most obvious feature of this striking cat is their lack of a fur coat; however, Sphynx cats vary in the degree of hairlessness, with some having a very fine ‘peach fuzz’ all over and others just a fine fuzz over the extremities. Due to the lack of fur, the Sphynx cats bone structure and musculature is there for all to see, and this is a remarkably robust cat, built on elegant long lines, with somewhat loose skin that forms wrinkles in some places.", CategoryId=1},
               new { Id = 2, Name = "GoldFish", Price = 10, PictureName = "https://i.pinimg.com/736x/a4/87/61/a48761892b48ea5731eda4ec2fb3e0c4.jpg", Description= "Thank the Chinese for today’s beloved aquarium mainstay, the goldfish. A type of carp, goldfish were domesticated nearly 2,000 years ago for use as ornamental fish in ponds and tanks. They were seen as a symbol of luck and fortune, and they could only be owned by members of the Song Dynasty.", CategoryId=2},
               new { Id = 3, Name = "Hamster", Price = 5, PictureName = "https://i.pinimg.com/564x/f8/a8/20/f8a82024fb3bcd165d551dc3f8311da7.jpg", Description= "hamster, any of 18 Eurasian species of rodents possessing internal cheek pouches. The golden hamster (Mesocricetus auratus) of Syria is commonly kept as a pet. Hamsters are stout-bodied, with a tail much shorter than their body length, and have small furry ears, short stocky legs, and wide feet.", CategoryId=3},
               new { Id = 4, Name = "Mainecoon", Price = 4500, PictureName = "https://i.pinimg.com/564x/cc/7f/dd/cc7fdd600e9a7b654945ecc9bf8703ed.jpg", Description= "The Maine Coon is solid, rugged, and can endure a harsh climate. A distinctive characteristic of this cat is the smooth, shaggy coat. This breed is well-proportioned, has a balanced appearance, and has adapted to varied environments.", CategoryId=1},
               new { Id = 5, Name = "Persian cat", Price = 1200, PictureName = "https://i.pinimg.com/564x/2f/99/89/2f998935bb27a37345e2aaeffe11b7cc.jpg", Description= "The Persian cat has been cherished for hundreds—if not thousands—of years, tracing its origins to the deserts of Persia and Iran. Today, the Persian cat is the most popular pedigreed cat breed in the U.S.. The Persian cat is a medium- to large-sized breed.", CategoryId=1},
               new { Id = 6, Name = "Bicolor Angelfish", Price = 49, PictureName = "https://www.liveaquaria.com/images/categories/large/lg66076BicolorAngelfish.jpg", Description= "Thought by many to be the most striking of the Centropyge group of dwarf or pygmy angelfish, the Bicolor Angelfish, also known as the Two-colored Angelfish or Oriole Angelfish, is a vibrant yellow on the anterior half of its body and a deep blue on the posterior half. A splash of deep blue extends upward vertically from the eye to the top of the head and the tail is yellow.", CategoryId=2},
               new { Id = 7, Name = "Green Chromis", Price = 9, PictureName = "https://fragbox.ca/wp-content/uploads/2022/02/blue-green-chromis.jpg", Description= "The Blue Green Reef Chromis is easy to care for, beautiful, and peaceful. In fact, Chromis viridis is one of the preferred marine reef fish amongst aquarists, regardless of their experience level. This member of the Pomacentridae family is most recognizable by its gorgeous light blue dorsal side that slowly fades into a majestic pale green belly. ", CategoryId=2},
               new { Id = 8, Name = "Amphiprioninae", Price = 26, PictureName = "https://www.starfish.ch/photos/fishes-Fische/damselfishes-Riffbarsche/Amphiprion-ocellaris11.jpg", Description= "Anemonefishes are a subfamily of the damselfishes. Contains 2 genera and 26 species. They are also called clown fishes.", CategoryId=2},
               new { Id = 9, Name = "Cavia porcellus", Price = 55, PictureName = "https://www.animalcenter.co.il/wp-content/uploads/2018/08/guinea-pig.jpg", Description= "The domestic guinea pig is a descendant of the wild cavy (Cavia aperea) which is a common rodent in South America (Kunzl and Sachser, 1999). It is a non-burrowing, herbivorous, crepuscular, hystricomorph (porcupine-like) rodent with a stocky body, short neck and limbs, and with either no tail or a vestigial one", CategoryId=3},
               new { Id = 10, Name = "Chinchilla", Price =75, PictureName = "https://upload.wikimedia.org/wikipedia/commons/1/18/Chinchilla_lanigera_%28Wroclaw_zoo%29-2.JPG", Description= "Smaller than a house cat, with large, dark eyes, velvety rounded ears, and plush, grayish fur, the chinchilla is perhaps one of the most enchanting rodents around! They are wildly social, living in family groups, which can form vast colonies, called herds, of over 100 individuals.", CategoryId=3}
           );
            modelBuilder.Entity<Comment>().HasData(
             new { Id = 1, AnimalId=1, Content="hiiii"},
             new { Id = 2, AnimalId=2, Content = "hiiii2" },
             new { Id = 3, AnimalId=1, Content = "hiiii3" },
             new { Id = 4, AnimalId=2, Content = "hiiii4" },
             new { Id = 5, AnimalId=3, Content = "hiiii5" }
         );

        }
    }
}
