using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    internal class SearchEngineService
    {
        private const string API_URL = "http://localhost:5144/Search";
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri(API_URL) };

        internal static async Task<string> SearchAsync(ISearchInputModel searchInput)
        {
            if (searchInput == null)
            {
                throw new ArgumentNullException(nameof(searchInput), "Search input cannot be null.");
            }

            var jsonContent = JsonConvert.SerializeObject(searchInput);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage? response = null;
            try
            {
                response = await client.PostAsync(API_URL, content);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception occurred while calling the API: {ex.Message}");
                throw new HttpRequestException("Error occurred while sending the request.", ex);
            }

            if (response == null)
            {
                throw new HttpRequestException("No response received from the API.");
            }

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to call the API. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, Content: {responseContent}");
            }
        }
    }
}
