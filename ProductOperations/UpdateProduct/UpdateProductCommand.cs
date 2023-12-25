using AutoMapper;
using ProductManage.DBOperations;

namespace ProductManage.ProductOperations.UpdateProduct;

// The UpdateProductCommand class handles the update of an existing product.
public class UpdateProductCommand
{
    public int ProductId { get; set; }
    public UpdateProductModel Model { get; set; }
    private readonly ProductDbContext _productDbContext;

    public UpdateProductCommand(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public void handle()
    {
        var existProduct = _productDbContext.Products.FirstOrDefault(p => p.Id == ProductId);

        if (existProduct != null)
        {
            existProduct.Name = Model.Name;
            existProduct.Price = Model.Price;
            _productDbContext.SaveChanges();
            return;
        }

        throw new InvalidOperationException("Product is not exist");
    }
}

public class UpdateProductModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

