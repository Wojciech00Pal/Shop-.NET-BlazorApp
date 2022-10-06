using shop.Plugins.EFCore;
using Shop.CoreBusiness;

namespace Shop.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly shopContext db;
        public ProductRepository(shopContext db)
        {
            this.db = db;
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