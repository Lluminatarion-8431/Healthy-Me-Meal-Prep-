using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Healthy_Me.Models
{
    public class RecipeSearch
    {

        public RecipeSearch()
        {

        }

        public string GetRecipeSearchURL(Customer customer)
        {
            return $"https://edamam-recipe-search.p.rapidapi.com/search" + PrivateAPIKeys.recipeSearchAPIKey;
        }

        public async Task<Customer> GetRecipeSearch(Customer customer)
        {
            string apiURL = GetRecipeSearchURL(customer);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiURL);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
                    JToken results = jsonResults["hits"][1];
                }
            }
            return customer;
        }
    }
}