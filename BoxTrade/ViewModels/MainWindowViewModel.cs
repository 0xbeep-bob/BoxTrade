using BoxTrade.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoxTrade.ViewModels
{
    public class MainWindowViewModel
    {
        HttpClient client = new HttpClient();
        string requeststring = "https://esi.evetech.net/latest/markets/10000002/orders/?type_id=34133";

        public MainWindowViewModel()
        {
            CalculateAsync();


        }

        public async Task CalculateAsync()
        {
            var data = await GetDataAsync(requeststring);

            var prices = JsonConvert.DeserializeObject<List<OrderModel>>(data);

            var minPrice = prices.Where(x => x.is_buy_order = true && x.system_id == 30000142).Max(x => x.price);
        }

        public async Task<string> GetDataAsync(string source)
        {
            HttpResponseMessage response = await client.GetAsync(source);
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
