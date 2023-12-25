using ProductManage.Models;
using ProductManage.ProductOperations.CreateProduct;
using ProductManage.ProductOperations.GetProductDetail;
using ProductManage.ProductOperations.GetProducts;
using ProductManage.ProductOperations.UpdateProduct;

namespace ProductManage.Services;

// The IProductServices interface defines the contract for product-related services.
public interface IProductServices
{
    List<ProductViewModel> GetProducts();
    ProductDetailViewModel GetProductById(int id);
    void CreateProduct(CreateProductModel newProduct);
    void UpdateProduct(int id, UpdateProductModel updateProduct);
    void DeleteProduct(int id);
}