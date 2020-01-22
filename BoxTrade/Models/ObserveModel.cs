using BoxTrade.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTrade.Models
{
    public class ObserveModel : NotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private decimal _price;
        private decimal _weigth;

        public int Id { get => _id; set => SetPropertyValue(ref _id, value); }
        public string Name { get => _name; set => SetPropertyValue(ref _name, value); }
        public decimal Price { get => _price; set => SetPropertyValue(ref _price, value); }
        //public decimal Weigth { get => _weigth; set => SetPropertyValue(ref _weigth, value); }
    }
}
