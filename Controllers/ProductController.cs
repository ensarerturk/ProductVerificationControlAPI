using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProductManage.DBOperations;
using ProductManage.ProductOperations.CreateProduct;
using ProductManage.ProductOperations.DeleteProduct;
using ProductManage.ProductOperations.GetProductDetail;
using ProductManage.ProductOperations.UpdateProduct;
using ProductManage.Services;

namespace ProductManage.Controllers;

// The ProductController class handles HTTP requests related to product operations.
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductServices _productService;
    private readonly ProductDbContext _productDbContext;
    private readonly IValidator<CreateProductModel> _createValidator;
    private readonly IValidator<UpdateProductModel> _updateValidator;
    private readonly IValidator<ProductDetailViewModel> _detailtValidator;
    private readonly IValidator<DeleteProductCommand> _deleteProductCommandValidator;

    public ProductController(IProductServices productService, IValidator<CreateProductModel> createValidator, IValidator<UpdateProductModel> updateValidator, IValidator<ProductDetailViewModel> detailtValidator, IValidator<DeleteProductCommand> deleteProductCommandValidator, ProductDbContext productDbContext)
    {
        _productService = productService;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _detailtValidator = detailtValidator;
        _deleteProductCommandValidator = deleteProductCommandValidator;
        _productDbContext = productDbContext;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        try
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        
        
        var productById = _productService.GetProductById(id);
        if (productById == null)
        {
            return NotFound();
        }

        return Ok(productById);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductModel newProduct)
    {
        try
        {
            var validationResult = _createValidator.Validate(newProduct);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            if (string.IsNullOrEmpty(newProduct.Name) || newProduct.Price < 0)
            {
                return BadRequest("Name and Price are required fields.");
            }

            _productService.CreateProduct(newProduct);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Name }, newProduct);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] UpdateProductModel updatedProduct)
    {
        try
        {
            var validationResult = _updateValidator.Validate(updatedProduct);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }
            
            _productService.UpdateProduct(id, updatedProduct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        try
        {
            DeleteProductCommand productCommand = new DeleteProductCommand(_productDbContext);
            productCommand.ProductId = id;
            
            var validationResult = _deleteProductCommandValidator.Validate(productCommand);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }
            
            _productService.DeleteProduct(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}