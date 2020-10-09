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

            
        }
    }

}
