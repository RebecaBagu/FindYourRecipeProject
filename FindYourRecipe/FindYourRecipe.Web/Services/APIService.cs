using System;
using System.Text;
using FindYourRecipe.Contracts.Models;
using Newtonsoft.Json;

namespace FindYourRecipe.Web.Services
{
	public abstract class APIService
	{
		
		HttpClient _client;
		public APIService(HttpClient client)
		{
			_client = client;
		}

		public async virtual Task<T> GetAsync<T>(string route)
		{
			var result = await _client.GetAsync(route);
			result.EnsureSuccessStatusCode();
			var json=await result.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(json);
        }

		public async virtual Task DeleteAsync(string route)
		{
			var result = await _client.DeleteAsync(route);
			result.EnsureSuccessStatusCode();
		}

		public async virtual Task<T> PostAsync<T>(string route, object request)
		{
			var json = JsonConvert.SerializeObject(request);
			var data = new StringContent(json, Encoding.UTF8, "application/json");
			var result = await _client.PostAsync(route, data);
			result.EnsureSuccessStatusCode();
			var jsonResult= await result.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(jsonResult);
		}

        public async virtual Task<T> PutAsync<T>(string route, object request)
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

