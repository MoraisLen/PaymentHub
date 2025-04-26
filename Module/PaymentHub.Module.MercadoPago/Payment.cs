using PaymentHub.MercadoPago.Config.HttpRequest;
using PaymentHub.MercadoPago.Config.Map;
using PaymentHub.MercadoPago.HttpRequest;
using PaymentHub.MercadoPago.HttpRequest.Request.CreatePayment;
using PaymentHub.MercadoPago.HttpRequest.Request.SearchPayment;
using PaymentHub.MercadoPago.HttpRequest.Request.UpdatePayment;
using PaymentHub.MercadoPago.Model;
using PaymentHub.MercadoPago.Model.Enum;

namespace PaymentHub.Module.MercadoPago
{
    public class Payment
    {
        private PaymentHttpRequest _httpRequest;
        private ConfigHttpRequest _configHttpRequest;

        public Payment(ConfigHttpRequest config)
        {
            _httpRequest = new PaymentHttpRequest(config);
            _configHttpRequest = config;
        }

        public async Task<PaymentDetailModel?> CreateAsync(PaymentModel request)
        {
            request.ReferenciaExterna = _configHttpRequest.ReferenciaExterna ?? request.ReferenciaExterna;
            CreatePaymentResponse payment = await _httpRequest.CreatePaymentAsync(Mapping.CreatePaymentRequest(request));

            return payment != null
                ? Mapping.PaymentDetailModel(payment)
                : null;
        }

        public async Task<List<PaymentDetailModel>> GetAsync(PaymentTypeStatusEnum? status = null)
        {
            SearchPaymentResponse response = await _httpRequest.SearchPaymentAsync();

            if (status != null)
                response.results = response.results.Where(x => x.status == ((PaymentTypeStatusConvertEnum)status).ToString()).ToList();

            return Mapping.PaymentDetailModelList(response);
        }

        public async Task<PaymentDetailModel?> GetAsync(string Id)
        {
            SearchPaymentDetailResponse response = await _httpRequest.SearchPaymentAsync(Id);

            return response != null
                ? Mapping.PaymentDetailModel(response)
                : null;
        }

        public async Task<PaymentDetailModel?> CancellAsync(string Id, PaymentTypeStatusEnum paymentTypeStatus = PaymentTypeStatusEnum.cancelado)
        {
            PaymentDetailModel? payment = await GetAsync(Id);

            if (payment != null)
            {
                UpdatePaymentRequest request = new UpdatePaymentRequest()
                {
                    status = ((PaymentTypeStatusConvertEnum)paymentTypeStatus).ToString()
                };

                CreatePaymentResponse result = await _httpRequest.UpdatePaymentAsync(Id, request);

                return result != null
                    ? Mapping.PaymentDetailModel(result)
                    : null;
            }
            else
            {
                return null;
            }
        }
    }
}