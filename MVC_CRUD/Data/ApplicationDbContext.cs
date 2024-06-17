using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;

namespace MVC_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                               new Category { Id = 1, Name = "花果茶", DisplayOrder = 1 },
                               new Category { Id = 2, Name = "柳橙汁", DisplayOrder = 2 },
                               new Category { Id = 3, Name = "咖啡", DisplayOrder = 3 },
                               new Category { Id = 4, Name = "琴酒", DisplayOrder = 4 },
                               new Category { Id = 5, Name = "威士忌", DisplayOrder = 5 },
                               new Category { Id = 6, Name = "龍舌蘭", DisplayOrder = 6 }
                               );
        }


    }
}
