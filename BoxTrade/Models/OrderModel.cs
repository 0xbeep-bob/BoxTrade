using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTrade.Models
{
    public class OrderModel
    {
        public int Duration { get; set; }
        public bool IsBuyOrder { get; set; }
        public DateTime Issued { get; set; }
        public object LocationId { get; set; }
        public int MinVolume { get; set; }
        public object OrderId { get; set; }
        public decimal Price { get; set; }
        public string Range { get; set; }
        public int SystemId { get; set; }
        public int TypeId { get; set; }
        public int VolumeRemain { get; set; }
        public int VolumeTotal { get; set; }
    }
}
