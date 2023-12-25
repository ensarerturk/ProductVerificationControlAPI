using Microsoft.EntityFrameworkCore;
using ProductManage.Models;

namespace ProductManage.DBOperations;

// The DataGenerator class is responsible for seeding initial data into the database.
public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context =
               new ProductDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProductDbContext>>()))
        {
            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(
                new Product
                {
                    Id = 1,
                    Name = "Kalem",
                    Price = 10,
                    GenreId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Defter",
                    Price = 20,
                    GenreId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Cetvel",
                    Price = 30,
                    GenreId = 3
                }
            );

            context.SaveChanges();
        }
    }
}