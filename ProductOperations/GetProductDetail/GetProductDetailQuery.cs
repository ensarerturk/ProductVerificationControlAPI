using AutoMapper;
using ProductManage.Common;
using ProductManage.DBOperations;

namespace ProductManage.ProductOperations.GetProductDetail;

// The GetProductDetailQuery class handles the retrieval of detailed information for a product.
public class GetProductDetailQuery
{
    public int ProductId { get; set; }
    private readonly ProductDbContext _productDbContext;
    private readonly IMapper _mapper;

    public GetProductDetailQuery(ProductDbContext productDbContext, IMapper mapper)
    {
        _productDbContext = productDbContext;
        _mapper = mapper;
    }

    public ProductDetailViewModel Handle()
    {
        var product = _productDbContext.Products.FirstOrDefault(p => p.Id == ProductId);
        if (product is null)
        {
            throw new InvalidOperationException("Product is empty");
        }

        ProductDetailViewModel vm = _mapper.Map<ProductDetailViewModel>(product);
        return vm;
    }
}

public class ProductDetailViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Genre { get; set; }
}