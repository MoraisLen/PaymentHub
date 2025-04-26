using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaymentHub.MercadoPago.Config.HttpRequest;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PaymentHub.MercadoPago.HttpRequest
{
    public class BaseHttp
    {
        private readonly HttpClient _httpClient = new HttpClient();
        protected ConfigHttpRequest _config;

        public BaseHttp(ConfigHttpRequest config)
        {
            _config = config;

            if (string.IsNullOrWhiteSpace(config.UrlBase) || string.IsNullOrWhiteSpace(config.Token))
                throw new ArgumentNullException("Configure o baseUrl e o token.");

            if (!string.IsNullOrEmpty(config.Token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.Token);
        }

        public async Task<T> GetAsync<T>(string path)
        {
            setIdempotency();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_config.UrlBase}/{path}");

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro BadRequest ao fazer requisição GET para {path}. Mensagem: {errorResponse}");
            }

            return default;
        }

        public async Task<T> PostAsync<T>(string path, object data)
        {
            setIdempotency();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config.UrlBase}/{path}", data);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro BadRequest ao fazer requisição POST para {path}. Mensagem: {errorResponse}");
            }
            else
            {
                throw new Exception($"Falha ao fazer requisição POST para {path}. Status: {response.StatusCode}");
            }
        }

        public async Task<T> PutAsync<T>(string path, object data)
        {
            setIdempotency();
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_config.UrlBase}/{path}", data);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro BadRequest ao fazer requisição POST para {path}. Mensagem: {errorResponse}");
            }
            else
            {
                throw new Exception($"Falha ao fazer requisição POST para {path}. Status: {response.StatusCode}");
            }
        }

        private void setIdempotency()
        {
            if (_config.FlUsaIdempotency)
            {
                _httpClient.DefaultRequestHeaders.Remove("X-Idempotency-Key");
                _httpClient.DefaultRequestHeaders.Add("X-Idempotency-Key", Guid.NewGuid().ToString());
            }
        }
    }
}