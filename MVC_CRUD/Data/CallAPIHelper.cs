using MVC_CRUD.Models;
namespace MVC_CRUD.Data
{
    public class CallAPIHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CallAPIHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Category>> GetCategoriesFromApi(string apiUrl)
        {
            var categories = new List<Category>();

            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(apiUrl);

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
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(apiUrl);

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
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(apiUrl, obj);

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
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(apiUrl, obj);

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
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync(apiUrl,null);

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
