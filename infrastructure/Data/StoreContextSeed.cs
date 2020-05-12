using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerfactory)
        {
            try
            {
                if(!context.productBrands.Any())
                {
                   var brandsData=File.ReadAllText("../infrastructure/Data/SeedData/brands.json");
                   var brands =JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                   foreach( var item in brands)
                   {
                       context.productBrands.Add(item);
                   }
                   await context.SaveChangesAsync();
                }   
            
             if(!context.productTypes.Any())
                {
                   var TypeData=File.ReadAllText("../infrastructure/Data/SeedData/types.json");
                   var types =JsonSerializer.Deserialize<List<ProductType>>(TypeData);
                   foreach( var item in types)
                   {
                       context.productTypes.Add(item);
                   }
                   await context.SaveChangesAsync();
                }
                
            if(!context.products.Any())
                {
                   var ProductData=File.ReadAllText("../infrastructure/Data/SeedData/products.json");
                   var products =JsonSerializer.Deserialize<List<Product>>(ProductData);
                   foreach( var item in products)
                   {
                       context.products.Add(item);
                   }
                   await context.SaveChangesAsync();
                }   
            }
            catch(Exception ex)
            {
                var logge = loggerfactory.CreateLogger<StoreContextSeed>();
                logge.LogError(ex.Message);
            }
            
            
 }
            
            
            }
            }