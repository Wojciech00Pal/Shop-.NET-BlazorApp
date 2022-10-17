using shop.CoreBusiness;
using shop.Plugins.EFCore;
using shop.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.UseCases
{
    public class LoadSoldItemsUseCase : ILoadSoldItemsUseCase
    {
        private readonly ISoldItemsRepository soldItemsRepository;

        public LoadSoldItemsUseCase(ISoldItemsRepository soldItemsRepository)
        {
            this.soldItemsRepository = soldItemsRepository;
        }

        public async Task<List<SoldItems>> ExecuteAsync(int id)
        {
            return await soldItemsRepository.LoadSoldItems(id);
        }
    }
}
