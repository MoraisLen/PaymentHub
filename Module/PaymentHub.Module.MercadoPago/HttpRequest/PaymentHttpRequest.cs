using PaymentHub.MercadoPago.Config.HttpRequest;
using PaymentHub.MercadoPago.HttpRequest.Request.CreatePayment;
using PaymentHub.MercadoPago.HttpRequest.Request.CreatePreference;
using PaymentHub.MercadoPago.HttpRequest.Request.SearchPayment;
using PaymentHub.MercadoPago.HttpRequest.Request.SearchPreference;
using PaymentHub.MercadoPago.HttpRequest.Request.UpdatePayment;
using PaymentHub.MercadoPago.Model;

namespace PaymentHub.MercadoPago.HttpRequest
{
    public class PaymentHttpRequest : BaseHttp
    {
        public PaymentHttpRequest(ConfigHttpRequest config) : base(config)
        { }

        public async Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
        {
            return await PostAsync<CreatePaymentResponse>("v1/payments", request);
        }

        public async Task<SearchPaymentResponse> SearchPaymentAsync()
        {
            return await GetAsync<SearchPaymentResponse>($"v1/payments/search?external_reference={_config.ReferenciaExterna}");
        }

        public async Task<SearchPaymentDetailResponse> SearchPaymentAsync(string Id)
        {
            return await GetAsync<SearchPaymentDetailResponse>($"v1/payments/{Id}");
        }

        public async Task<CreatePaymentResponse> UpdatePaymentAsync(string Id, UpdatePaymentRequest updatePayment)
        {
            return await PutAsync<CreatePaymentResponse>($"v1/payments/{Id}", updatePayment);
        }
    }
}