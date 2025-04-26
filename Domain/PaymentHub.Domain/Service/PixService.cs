using Microsoft.Extensions.Configuration;
using PaymentHub.Domain.Interface;
using PaymentHub.MercadoPago.Config.HttpRequest;
using PaymentHub.MercadoPago.Model;
using PaymentHub.MercadoPago.Model.Enum;
using PaymentHub.Module.MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHub.Domain.Service
{
    public class PixService: IPixService
    {
        private Payment _payment;

        public PixService(IConfiguration configuration)
        {
            ConfigHttpRequest config = new ConfigHttpRequest
            {
                FlUsaIdempotency = true,
                ReferenciaExterna = configuration["PaymentMethod:MercadoPago:ReferenciaExterna"] ?? string.Empty,
                Token = configuration["PaymentMethod:MercadoPago:Token"] ?? string.Empty,
                UrlBase = configuration["PaymentMethod:MercadoPago:UrlBase"] ?? string.Empty
            };

            _payment = new Payment(config);
        }

        public async Task<PaymentDetailModel?> CreateAsync(PaymentModel request)
        {
            return await _payment.CreateAsync(request);
        }

        public async Task<List<PaymentDetailModel>> GetAsync(PaymentTypeStatusEnum? status = null)
        {
            return await _payment.GetAsync(status);
        }

        public async Task<PaymentDetailModel?> GetAsync(string Id)
        {
            return await _payment.GetAsync(Id);
        }

        public async Task<PaymentDetailModel?> CancellAsync(string Id)
        {
            return await _payment.CancellAsync(Id);
        }
    }
}
