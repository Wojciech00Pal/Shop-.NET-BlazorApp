using shop.Plugins.EFCore;

using Microsoft.EntityFrameworkCore;
using shop.CoreBusiness;
using shop.UseCases.pluginInterfaces;

namespace Shop.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly shopContext db;
        public ProductRepository(shopContext db)
        {
            this.db = db;
        }
        public async Task UpdateProducts(Products pr)
        {
            var prod = await db.Products.FindAsync(pr.ProductId);
            if (prod != null)
            {
                prod.ProductName = pr.ProductName;
                prod.Price = pr.Price;
                prod.Quantity = pr.Quantity;
                prod.Sum = pr.Sum;

                await db.SaveChangesAsync();
            }
        }
        public async Task AddAsync(int productId, int quantity)
        {
            var prodStorage = await GetStorageProductById(productId);

            if (prodStorage.StorageQuantity - quantity >= 0)//correct
            {
                //  prodStorage.StorageQuantity -= quantity;
                //later, after confirmation
                if (await GetProductById(productId) == null)//nie ma jeszcze na liscie zakupow
                {
                    var prod = new Products
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        ProductName = prodStorage.Name,
                        Price = prodStorage.Price
                    };

                    await db.Products.AddAsync(prod);
                    await db.SaveChangesAsync();
                }
                else //jest juz na liscie
                {
                    var prod = await GetProductById(productId);
                    prod.Quantity+=quantity;
                }
             }
            else
            {
                //not enough products, only:
                int left = prodStorage.StorageQuantity;
            }

        }

        public async Task<List<Products>> LoadProducts()
        {
            //return await this.db.Products.ToListAsync();
              return await this.db.Products.Where
              (x => x!=null).ToListAsync();//not shown these without  active==true            
        }

        public async Task<Products> GetProductById(int id)
        {
            return await this.db.Products.FindAsync(id);
        }


        public async Task<ProductStorage> GetStorageProductById(int id)
        {
            return await this.db.ProductStorage.FindAsync(id);
        }
    }
}