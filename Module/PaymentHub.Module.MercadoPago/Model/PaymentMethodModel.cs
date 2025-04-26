using PaymentHub.MercadoPago.HttpRequest.Request.PaymentMethod;

namespace PaymentHub.MercadoPago.Model
{
    public class PaymentMethodModel
    {
        public string IdPagamento { get; set; }
        public string NomePagamento { get; set; }
        public string IdTipoPagamento { get; set; }
    }
}
