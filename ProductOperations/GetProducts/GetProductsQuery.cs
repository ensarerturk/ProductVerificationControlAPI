using AutoMapper;
using ProductManage.Common;
using ProductManage.DBOperations;
using ProductManage.Models;

namespace ProductManage.ProductOperations.GetProducts;

// The GetProductsQuery class handles the retrieval of a list of products.
public class GetProductsQuery
{
    private readonly ProductDbContext _productDbContext;
    private readonly IMapper _mapper;

    public GetProductsQuery(ProductDbContext productDbContext, IMapper mapper)
    {
        _productDbContext = productDbContext;
        _mapper = mapper;
    }

    public List<ProductViewModel> Handle()
    {
        var productList = _productDbContext.Products.ToList();
        List<ProductViewModel> vm = _mapper.Map<List<ProductViewModel>>(productList);

        return vm;
    }
}

public class ProductViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Genre { get; set; }
}