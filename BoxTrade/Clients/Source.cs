using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoxTrade.Clients
{
    public class Source
    {
        HttpClient client = new HttpClient();

        public static Source Instance => new Source();

        private Source() { }

        public async Task<string> GetDataAsync(string source)
        {
            HttpResponseMessage response = await client.GetAsync(source);
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
