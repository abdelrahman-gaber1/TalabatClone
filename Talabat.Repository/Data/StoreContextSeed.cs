using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext _dbContext)
        {
            var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            if (brands.Count() > 0)
            {
                if (_dbContext.productsBrands.Count() == 0) 
                {
                    foreach (var brand in brands)
                    {
                        _dbContext.Set<ProductBrand>().Add(brand);
                    }
                    await   _dbContext.SaveChangesAsync();
                }
            }

            var categorydata = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");
            var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categorydata);
            if (categories.Count() > 0)
            {
                if (_dbContext.productCategories.Count() == 0)
                {
                    foreach (var category in categories)
                    {
                        _dbContext.Set<ProductCategory>().Add(category);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            var productsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            if (products.Count() > 0)
            {
                if (_dbContext.products.Count() == 0)
                {
                    foreach (var product in products)
                    {
                        _dbContext.Set<Product>().Add(product);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
