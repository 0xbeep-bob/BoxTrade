﻿using BoxTrade.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTrade.Models
{
    public class ObserveModel : NotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private decimal _buyPrice;
        private decimal _npcSellPrice;
        private decimal _npcSellPriceTax;
        private decimal _marginIsk;
        private decimal _marginPercent;
        private decimal _weigth;

        public int Id { get => _id; set => SetPropertyValue(ref _id, value); }
        public string Name { get => _name; set => SetPropertyValue(ref _name, value); }
        public decimal BuyPrice { get => _buyPrice; set => SetPropertyValue(ref _buyPrice, value); }
        public decimal NPCSellPrice { get => _npcSellPrice; set => SetPropertyValue(ref _npcSellPrice, value); }
        public decimal NPCSellPriceTax { get => _npcSellPriceTax; set => SetPropertyValue(ref _npcSellPriceTax, value); }
        public decimal MarginIsk { get => _marginIsk; set => SetPropertyValue(ref _marginIsk, value); }
        public decimal MarginPercent { get => _marginPercent; set => SetPropertyValue(ref _marginPercent, value); }
        //public decimal Weigth { get => _weigth; set => SetPropertyValue(ref _weigth, value); }
    }
}
