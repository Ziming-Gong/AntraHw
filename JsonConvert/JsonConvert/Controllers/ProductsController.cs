using System.Collections;
using ApplicationCore.Entity;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsonConvert.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductServices _productServices;

    public ProductsController(IProductServices productServices)
    {
        _productServices = productServices;
    }

    // GET
    [HttpGet("GetAll")]
    public async Task<List<Product>> GetAll()
    {
        return await _productServices.GetAllProduct();
    }

    [HttpGet("{str}")]
    public async Task<List<Product>> GetByCategory(string str)
    {
        return await _productServices.GetByCategory(str);
    }

}