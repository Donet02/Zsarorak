using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _03_17
{
    public class ServerConnection
    {
        HttpClient client = new HttpClient();
        public ServerConnection(string url)
        {
            client.BaseAddress = new Uri(url);

        }
        public async Task<Geckos> GetGeckos()
        {
            try
            {
                HttpResponseMessage r = await client.GetAsync("/geckos");
                r.EnsureSuccessStatusCode();
                string re = await r.Content.ReadAsStringAsync();           
                Geckos result = JsonSerializer.Deserialize<Geckos>(re);
                return result;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<bool> DeleteGecko()
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/gecko");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<bool> CreateGecko(string newGecko)
        {
            try
            {
                var jsonData = new { gecko = newGecko };
                string jsonString = JsonSerializer.Serialize(jsonData);
                StringContent sendThis = new StringContent(jsonString, Encoding.UTF8, "Application/JSON");
                HttpResponseMessage response = await client.PostAsync("/gecko", sendThis);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<Gecko> LeopardGecko()
        {
            try
            {
                HttpResponseMessage r = await client.GetAsync("/leopardgecko");
                r.EnsureSuccessStatusCode();
                string re = await r.Content.ReadAsStringAsync();
                Gecko result = JsonSerializer.Deserialize<Gecko>(re);
                return result;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<advancedgecko> AdvGecko()
        {
            try
            {
                HttpResponseMessage r = await client.GetAsync("/advancedgecko");
                r.EnsureSuccessStatusCode();
                string re = await r.Content.ReadAsStringAsync();
                advancedgecko result = JsonSerializer.Deserialize<advancedgecko>(re);
                return result;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
            
        }
        
    }
}
