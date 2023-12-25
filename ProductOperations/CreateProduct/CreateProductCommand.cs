using AutoMapper;
using ProductManage.DBOperations;
using ProductManage.Models;

namespace ProductManage.ProductOperations.CreateProduct;

// The CreateProductCommand class handles the creation of a new product.
public class CreateProductCommand
{
    public CreateProductModel Model { get; set; }
    private readonly ProductDbContext _productDbContext;
    private readonly IMapper _mapper;

    public CreateProductCommand(ProductDbContext productDbContext, IMapper mapper)
    {
        _productDbContext = productDbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var product = _productDbContext.Products.SingleOrDefault(x => x.Name == Model.Name);
        if (product is not null)
        {
            throw new InvalidOperationException("That book already exist");
        }
        product = _mapper.Map<Product>(Model);
        
        _productDbContext.Products.Add(product);
        _productDbContext.SaveChanges();

    }
}

public class CreateProductModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Genre { get; set; }
}