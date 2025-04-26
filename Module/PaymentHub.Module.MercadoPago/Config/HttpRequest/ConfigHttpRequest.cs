namespace PaymentHub.MercadoPago.Config.HttpRequest
{
    public class ConfigHttpRequest
    {
        public string Token { get; set; }
        public string UrlBase { get; set; }
        public string ReferenciaExterna { get; set; }
        public bool FlUsaIdempotency { set; get; }
    }
}