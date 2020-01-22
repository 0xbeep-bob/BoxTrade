using BoxTrade.Clients;
using BoxTrade.Helpers;
using BoxTrade.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoxTrade.ViewModels
{
    public class MainWindowViewModel
    {       
        public ObservableCollection<ObserveModel> ObserveList { get; set; }

        public MainWindowViewModel()
        {
            ObserveList = new ObservableCollection<ObserveModel>()
            {
                new ObserveModel(){ Id = 19417, Name = "19th Tier Overseer's Personal Effects" },
                new ObserveModel(){ Id = 19419, Name = "21th Tier Overseer's Personal Effects" },
                new ObserveModel(){ Id = 19421, Name = "23th Tier Overseer's Personal Effects" },
                new ObserveModel(){ Id = 48121, Name = "Triglavian Survey Database" },
            };

            ObserveList.AsParallel().ForAll(async x => await CalculateOrderAsync(x));
        }

        public async Task CalculateOrderAsync(ObserveModel model)
        {
            string OrdersJson = await Source.Instance.GetDataAsync($"{Consts.Instance.RequestString}/?type_id={model.Id}&system_id={30000144}&is_buy_order={true}");
            var orders = JsonConvert.DeserializeObject<List<OrderModel>>(OrdersJson);

            model.Price = orders.Max(x => x.Price);
        }
    }
}
