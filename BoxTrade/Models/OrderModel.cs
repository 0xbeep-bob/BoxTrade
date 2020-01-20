using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTrade.Models
{
    public class OrderModel
    {
        public int duration { get; set; }
        public bool is_buy_order { get; set; }
        public DateTime issued { get; set; }
        public object location_id { get; set; }
        public int min_volume { get; set; }
        public object order_id { get; set; }
        public decimal price { get; set; }
        public string range { get; set; }
        public int system_id { get; set; }
        public int type_id { get; set; }
        public int volume_remain { get; set; }
        public int volume_total { get; set; }
    }
}
