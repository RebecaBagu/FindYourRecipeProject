using System;
using System.Text;
using Newtonsoft.Json;

namespace FindYourRecipe.Web.Services
{
	public class APiService
	{
		HttpClient _client;
		public APiService(HttpClient client)
		{
			_client = client;
		}

		public async Task DeleteAsync(string route)
		{
			var result = await _client.DeleteAsync(route);
			result.EnsureSuccessStatusCode();
		}

		public async Task<T> GetAsync<T>(string route)
		{
			var result = await _client.GetAsync(route);
			result.EnsureSuccessStatusCode();
			var json = await result.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(json);
        }

		public async Task<T> PostAsync<T>(string route, object request)
		{
			var json = JsonConvert.SerializeObject(request);
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var result = await _client.PostAsync(route, data);
			result.EnsureSuccessStatusCode();
			var jsonResult= await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public async Task<T> PutAsync<T>(string route, object request)
        {
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PutAsync(route, data);
            result.EnsureSuccessStatusCode();
            var jsonResult = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }
    }
}

