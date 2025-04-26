using PaymentHub.MercadoPago.Config.HttpRequest;
using PaymentHub.MercadoPago.Config.Map;
using PaymentHub.MercadoPago.HttpRequest;
using PaymentHub.MercadoPago.HttpRequest.Request.PaymentMethod;
using PaymentHub.MercadoPago.Model;

namespace PaymentHub.Module.MercadoPago
{
    public class Util
    {
        private UtilHttpRequest _httpRequest;

        public Util(ConfigHttpRequest config)
        {
            _httpRequest = new UtilHttpRequest(config);
        }

        public async Task<List<PaymentMethodModel>> GetPaymentMethodsAsync()
        {
            List<PaymentMethodResponse> lstPayment = await _httpRequest.GetPaymentMethodModelsAsync();

            return lstPayment != null
                ? Mapping.PaymentMethodModelList(lstPayment)
                : new List<PaymentMethodModel>();
        }
    }
}