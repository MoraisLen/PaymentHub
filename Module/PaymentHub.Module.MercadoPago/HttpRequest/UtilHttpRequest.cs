using PaymentHub.MercadoPago.Config.HttpRequest;
using PaymentHub.MercadoPago.HttpRequest.Request.PaymentMethod;

namespace PaymentHub.MercadoPago.HttpRequest
{
    public class UtilHttpRequest : BaseHttp
    {
        public UtilHttpRequest(ConfigHttpRequest config) : base(config)
        { }

        public async Task<List<PaymentMethodResponse>> GetPaymentMethodModelsAsync()
        {
            return await GetAsync<List<PaymentMethodResponse>>("v1/payment_methods");
        }
    }
}