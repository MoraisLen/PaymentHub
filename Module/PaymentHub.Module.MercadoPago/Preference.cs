using PaymentHub.MercadoPago.Config.HttpRequest;
using PaymentHub.MercadoPago.Config.Map;
using PaymentHub.MercadoPago.HttpRequest;
using PaymentHub.MercadoPago.HttpRequest.Request.CreatePreference;
using PaymentHub.MercadoPago.HttpRequest.Request.SearchPreference;
using PaymentHub.MercadoPago.Model;

namespace PaymentHub.Module.MercadoPago
{
    public class Preference
    {
        private PreferenceHttpRequest _httpRequest;

        public Preference(ConfigHttpRequest config)
        {
            _httpRequest = new PreferenceHttpRequest(config);
        }

        public async Task<PreferenceModel?> CreateAsync(PreferenceModel request)
        {
            if (request.MetodoPagamento.MetodosPagamentoExcluidos.Any(x => x.Id == request.MetodoPagamento.MetodoPagamentoPadrao))
                throw new Exception($"O método padrão de pagamento não pode estar entre os excluídos");

            CreatePreferenceResponse preference = await _httpRequest.CreatePaymentAsync(Mapping.CreatePreferenceRequest(request));

            return preference != null
                ? Mapping.PreferenceModel(preference)
                : null;
        }

        public async Task<List<PreferenceItemModel>> SearchPreference()
        {
            SearchResponse search = await _httpRequest.SearchPreference();

            return search != null
                ? Mapping.SearchPreferenceResponse(search)
                : new List<PreferenceItemModel>();
        }

        public async Task<PreferenceModel?> SearchPreference(string Id)
        {
            CreatePreferenceResponse search = await _httpRequest.SearchPreferenceById(Id);

            return search != null
                ? Mapping.PreferenceModel(search)
                : null;
        }
    }
}