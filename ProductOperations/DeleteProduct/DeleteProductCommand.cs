using ProductManage.DBOperations;

namespace ProductManage.ProductOperations.DeleteProduct;

// The DeleteProductCommand class handles the deletion of an existing product.
public class DeleteProductCommand
{
    public int ProductId { get; set; }
    private readonly ProductDbContext _productDbContext;

    public DeleteProductCommand(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }
    
    public void handle()
    {
        var existProduct = _productDbContext.Products.FirstOrDefault(p => p.Id == ProductId);
        if (existProduct != null)
        {
            _productDbContext.Products.Remove(existProduct);
            _productDbContext.SaveChanges();
            return;
        }

        throw new InvalidOperationException("No books found to delete.");
    }
}