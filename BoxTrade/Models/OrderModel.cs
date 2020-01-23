using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTrade.Models
{
    //public class OrderModel
    //{
    //    public int Duration { get; set; }
    //    public bool IsBuyOrder { get; set; }
    //    public DateTime Issued { get; set; }
    //    public object LocationId { get; set; }
    //    public int MinVolume { get; set; }
    //    public object OrderId { get; set; }
    //    public decimal Price { get; set; }
    //    public string Range { get; set; }
    //    public int SystemId { get; set; }
    //    public int TypeId { get; set; }
    //    public int VolumeRemain { get; set; }
    //    public int VolumeTotal { get; set; }
    //}

    public class OrderModel
    {
        public int duration { get; set; }
        public bool is_buy_order { get; set; }
        public DateTime issued { get; set; }
        public object location_id { get; set; }
        public int min_volume { get; set; }
        public object order_id { get; set; }
        public double price { get; set; }
        public string range { get; set; }
        public int system_id { get; set; }
        public int type_id { get; set; }
        public int volume_remain { get; set; }
        public int volume_total { get; set; }
    }
}
