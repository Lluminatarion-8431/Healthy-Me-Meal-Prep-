using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Healthy_Me.Models
{
    public class BMI
    {
        public BMI()
        {

        }
        
        public string GetBMIURL(Customer customer)
        {
            return $"https://bmi.p.rapidapi.com/" + PrivateAPIKeys.BMIAPIKey;
        }

        public async Task<Customer> GetBMI(Customer customer)
        {
            string apiUrl = GetBMIURL(customer);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
                    JToken results = jsonResults["bmi"][1];
                    //JToken location = results["geometry"]["location"];
                }
            }
            return customer;
        }
    }
}
