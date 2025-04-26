namespace PaymentHub.MercadoPago.Model
{
    public class PreferenceItemModel
    {
        public string? Id { get; set; }
        public string IdCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataMinPagamento { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string EmailPagador { get; set; }
        public List<string> Itens { get; set; }
    }
}