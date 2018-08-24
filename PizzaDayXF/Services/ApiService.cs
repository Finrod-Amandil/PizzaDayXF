using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using PizzaDayXF.Models;

namespace PizzaDayXF.Services
{
    public class ApiService
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<List<MenuItem>> GetMenuItemsAsync(int restaurantId)
        {
            var data = await _client.GetStringAsync($"https://pizzaday.noser.com/api/restaurants/{restaurantId}/menu");
            return JsonConvert.DeserializeObject<List<MenuItem>>(data);
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            var data = await _client.GetStringAsync("https://pizzaday.noser.com/api/restaurants");
            return JsonConvert.DeserializeObject<List<Restaurant>>(data);
        }
    }
}
