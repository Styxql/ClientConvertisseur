using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Services
{
    internal class WSService : IService
    {
        private readonly HttpClient HttpClient;

        public WSService(string url)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:7211/api/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
