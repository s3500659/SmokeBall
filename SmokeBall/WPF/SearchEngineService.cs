using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

            HttpResponseMessage? response;
            try
            {
                response = await client.PostAsync(API_URL, content);
            }
            catch (Exception ex)
            {

                return "Error occurred while sending the request: " + ex;
            }

            if (response == null)
            {
                return "No response received from the API.";
            }

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Failed to get a successful response from the API. Status code: {response.StatusCode}";
            }
        }
    }
}
