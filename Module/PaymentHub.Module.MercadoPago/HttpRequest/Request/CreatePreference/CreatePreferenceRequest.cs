

namespace PaymentHub.MercadoPago.HttpRequest.Request.CreatePreference
{
    public class CreatePreferenceRequest
    {
        public string additional_info { get; set; }
        public DateTime? expiration_date_from { get; set; }
        public DateTime? expiration_date_to { get; set; }
        public bool expires { get; set; }
        public List<Item> items { get; set; }
        public Payer payer { get; set; }
        public PaymentMethods payment_methods { get; set; }

        public class PaymentMethods
        {
            public List<ExcludedPaymentMethod> excluded_payment_methods { get; set; }
            public List<ExcludedPaymentType> excluded_payment_types { get; set; }
            public string default_payment_method_id { get; set; }
        }

        public class Payer
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string email { get; set; }
            public Identification identification { get; set; }
            public DateTime date_created { get; set; }
        }

        public class ExcludedPaymentMethod
        {
            public string id { get; set; }
        }

        public class ExcludedPaymentType
        {
            public string id { get; set; }
        }

        public class Identification
        {
            public string type { get; set; }
            public string number { get; set; }
        }

        public class Item
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string picture_url { get; set; }
            public int quantity { get; set; }
            public string currency_id { get; set; }
            public decimal unit_price { get; set; }
        }
    }

}