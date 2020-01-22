using System;
using System.Collections.Generic;
using System.Text;

namespace BoxTrade.Helpers
{
    public class Consts
    {
        public static Consts Instance => new Consts();

        private Consts() { }

        /// <summary>
        /// url orders of the Forge region
        /// </summary>
        public string RequestString => "https://esi.evetech.net/latest/markets/10000002/orders";
    }
}
