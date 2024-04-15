// ProductService.cs

using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Group5_DBApp.Models;
using Microsoft.EntityFrameworkCore;

public interface IProductService
{
    Task LogProducts();
}

public class ProductService : IProductService
{
    private readonly ILogger<ProductService> _logger;
    private readonly DataContext _context;

    public ProductService(ILogger<ProductService> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task LogProducts()
    {
        var products = await _context.Products.ToListAsync();
        
        // Log each product with its index
        for (int i = 0; i < products.Count; i++)
        {
            var product = products[i];
            _logger.LogInformation($"Product at index {i}: Product ID: {product.prod_id}, Name: {product.prod_name}, Price: {product.price}");
        }
    }
}