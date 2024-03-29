﻿using BoxTrade.Clients;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BoxTrade.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        public ICommand NewTaxCommand { get; }

        private decimal _sellTax;
        private decimal _buyTax;

        public ObservableCollection<ObserveModel> ObserveList { get; set; }
        public decimal SellTax { get => _sellTax; set => SetPropertyValue(ref _sellTax, value); }
        public decimal BuyTax { get => _buyTax; set => SetPropertyValue(ref _buyTax, value); }

        public MainWindowViewModel()
        {
            NewTaxCommand = new Command(NewTaxCommandBehavior);

            SellTax = 2.25m;

            ObserveList = new ObservableCollection<ObserveModel>()
            {
                new ObserveModel(){ Id = 19417, Name = "19th Tier Overseer's Personal Effects", NPCSellPrice = 51680000, Count=100 },
                new ObserveModel(){ Id = 19419, Name = "21th Tier Overseer's Personal Effects", NPCSellPrice = 80000000, Count=100 },
                new ObserveModel(){ Id = 19421, Name = "23th Tier Overseer's Personal Effects", NPCSellPrice = 133837000, Count=100 },
                new ObserveModel(){ Id = 48121, Name = "Triglavian Survey Database", NPCSellPrice = 100000, Count=100000 }
            };

            ObserveList.AsParallel().ForAll(async x => await CalculateOrderAsync(x));
            Task.Run(() => CycleUpdate(ObserveList));
        }

        public async Task CycleUpdate(ObservableCollection<ObserveModel> observeList)
        {
            while (true)
            {
                await Task.Delay(1000 * 60);
                observeList.AsParallel().ForAll(async x => await CalculateOrderAsync(x));
            }
        }

        public async Task CalculateOrderAsync(ObserveModel model)
        {
            try
            {
                //string OrdersJson = await Source.Instance.GetDataAsync($"{Consts.Instance.RequestString}/?type_id={model.Id}&system_id={30000144}&is_buy_order={true}"); // TODO: why this request give uncorrect data ?
                string OrdersJson = await Source.Instance.GetDataAsync($"{Consts.Instance.RequestString}/?type_id={model.Id}");
                var orders = JsonConvert.DeserializeObject<List<OrderModel>>(OrdersJson); // TODO: why not work with CamelCase properties?

                model.BuyPrice = (decimal)orders.Where(x => x.is_buy_order && x.system_id == (int)Systems.Perimeter).Max(x => x.price);
                model.NPCSellPriceTax = model.NPCSellPrice * (100 - SellTax) / 100;
                model.MarginIsk = model.NPCSellPriceTax - model.BuyPrice * (100 + BuyTax) / 100;
                model.MarginPercent = model.MarginIsk / model.BuyPrice * 100;
                model.MarginSum = model.Count * model.MarginIsk;
            }
            catch { } // TODO: add zero/error result logic
        }

        private void NewTaxCommandBehavior()
        {
            ObserveList.AsParallel().ForAll(x =>
            {
                x.NPCSellPriceTax = x.NPCSellPrice * (100 - SellTax) / 100;
                x.MarginIsk = x.NPCSellPriceTax - x.BuyPrice * (100 + BuyTax) / 100;
                x.MarginPercent = x.MarginIsk / x.BuyPrice * 100;
                x.MarginSum = x.Count * x.MarginIsk;
            });
        }
    }
}