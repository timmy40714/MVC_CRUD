using MVC_CRUD.Models;
using System.Net.Http.Json;
namespace MVC_CRUD.Data
{
    public class CallAPIHelper
    {
        private readonly HttpClient _httpClient;

        public CallAPIHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetCategoriesFromApi(string apiUrl)
        {
            var categories = new List<Category>();

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    categories = await response.Content.ReadFromJsonAsync<List<Category>>();
                }
                else
                {
                    // Handle error response
                    // Log or throw exception as needed
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // Log or throw exception as needed
            }

            return categories;
        }

        public async Task<Category> GetCategoryFromApi(string apiUrl)
        {
            var category = new Category();

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    category = await response.Content.ReadFromJsonAsync<Category>();
                }
                else
                {
                    // Handle error response
                    // Log or throw exception as needed
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // Log or throw exception as needed
            }

            return category;
        }
        public async Task<bool> CreateCategoryFromApi(string apiUrl, Category obj)
        {
            var response = await _httpClient.PostAsJsonAsync(apiUrl,obj);
            response.EnsureSuccessStatusCode();
            
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Handle error response
                // Log or throw exception as needed
                return false;
            }
        }
        public async Task<bool> UpdateCategoryFromApi(string apiUrl, Category obj)
        {
            var response = await _httpClient.PostAsJsonAsync(apiUrl, obj);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Handle error response
                // Log or throw exception as needed
                return false;
            }
        }
        public async Task<bool> DeleteCategoryFromApi(string apiUrl)
        {
            var response = await _httpClient.PostAsync(apiUrl,null);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Handle error response
                // Log or throw exception as needed
                return false;
            }
        }
    }
}
