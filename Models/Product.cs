using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManage.Models;

// The Product class represents the entity model for products in the application.
public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int GenreId { get; set; }
}