using PaymentHub.MercadoPago.Model;
using PaymentHub.MercadoPago.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHub.Domain.Interface
{
    public interface IPixService
    {
        Task<PaymentDetailModel?> CancellAsync(string Id);
        Task<PaymentDetailModel?> CreateAsync(PaymentModel request);
        Task<List<PaymentDetailModel>> GetAsync(PaymentTypeStatusEnum? status = null);
        Task<PaymentDetailModel?> GetAsync(string Id);
    }
}
