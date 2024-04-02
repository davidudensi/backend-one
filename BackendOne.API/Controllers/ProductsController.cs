using BackendOne.API.Interfaces;
using BackendOne.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendOne.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProduct _product;

    public ProductsController(ILogger<ProductsController> logger, IProduct product)
    {
        _logger = logger;
        _product = product;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _product.GetProductsAsync();
        if (response != null) return Ok(response);
        return NotFound("No products found");
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product input)
    {
        var response = await _product.AddProductAsync(input);
        if (response) return Ok(input);
        return BadRequest("Adding input to db failed");
    }
}
