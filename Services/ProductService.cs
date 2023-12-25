using AutoMapper;
using ProductManage.DBOperations;
using ProductManage.ProductOperations.CreateProduct;
using ProductManage.ProductOperations.DeleteProduct;
using ProductManage.ProductOperations.GetProductDetail;
using ProductManage.ProductOperations.GetProducts;
using ProductManage.ProductOperations.UpdateProduct;

namespace ProductManage.Services;

// The ProductServices class implements the IProductServices interface for product-related operations.
public class ProductServices : IProductServices
{
    private readonly ProductDbContext _productDbContext;
    private readonly IMapper _mapper;
    
    public ProductServices(ProductDbContext productDbContext, IMapper mapper)
    {
        _productDbContext = productDbContext;
        _mapper = mapper;
    }

    public List<ProductViewModel> GetProducts()
    {
        GetProductsQuery getProductsQuery = new GetProductsQuery(_productDbContext, _mapper);
        var result = getProductsQuery.Handle();
        return result;

    }

    public ProductDetailViewModel GetProductById(int id)
    {
        GetProductDetailQuery getProductsQuery = new GetProductDetailQuery(_productDbContext, _mapper);
        getProductsQuery.ProductId = id;
        var result = getProductsQuery.Handle();
        return result;
    }

    public void CreateProduct(CreateProductModel newProduct)
    {
        CreateProductCommand createProductCommand = new CreateProductCommand(_productDbContext, _mapper);
        createProductCommand.Model = newProduct;
        createProductCommand.Handle();
        
    }

    public void UpdateProduct(int id, UpdateProductModel updateProduct)
    {
        UpdateProductCommand updateProductCommand = new UpdateProductCommand(_productDbContext);
        updateProductCommand.ProductId = id;
        updateProductCommand.Model = updateProduct;
        updateProductCommand.handle();
    }

    public void DeleteProduct(int id)
    {
        DeleteProductCommand deleteProductCommand = new DeleteProductCommand(_productDbContext);
        deleteProductCommand.ProductId = id;
        deleteProductCommand.handle();
    }
}
