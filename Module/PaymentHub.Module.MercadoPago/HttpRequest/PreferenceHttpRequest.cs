using PaymentHub.MercadoPago.Config.HttpRequest;
using PaymentHub.MercadoPago.HttpRequest.Request.CreatePreference;
using PaymentHub.MercadoPago.HttpRequest.Request.SearchPreference;

namespace PaymentHub.MercadoPago.HttpRequest
{
    public class PreferenceHttpRequest : BaseHttp
    {
        public PreferenceHttpRequest(ConfigHttpRequest config) : base(config)
        { }

        public async Task<CreatePreferenceResponse> CreatePaymentAsync(CreatePreferenceRequest request)
        {
            return await PostAsync<CreatePreferenceResponse>("checkout/preferences", request);
        }

        public async Task<SearchResponse> SearchPreference()
        {
            return await GetAsync<SearchResponse>("checkout/preferences/search");
        }

        public async Task<CreatePreferenceResponse> SearchPreferenceById(string Id)
        {
            return await GetAsync<CreatePreferenceResponse>($"checkout/preferences/search/{Id}");
        }
    }
}