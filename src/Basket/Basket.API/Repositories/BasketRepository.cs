using Basket.API.Data;
using Basket.API.Data.Interfaces;
using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext context;

        public BasketRepository(IBasketContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteBasket(string userName)
        {
            return await context.Redis.KeyDeleteAsync(userName);
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket = await context.Redis.StringGetAsync(userName);
            if (basket.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            var updated = await context.Redis.StringSetAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            if (!updated)
            {
                return null;
            }
            return await GetBasket(basket.UserName);
        }
    }
}
