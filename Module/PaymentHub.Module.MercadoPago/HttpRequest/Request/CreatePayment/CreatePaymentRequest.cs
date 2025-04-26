namespace PaymentHub.MercadoPago.HttpRequest.Request.CreatePayment
{
    public class CreatePaymentRequest
    {
        public AdditionalInfo? additional_info { get; set; }
        public object? application_fee { get; set; }
        public bool binary_mode { get; set; }
        public object? campaign_id { get; set; }
        public bool? capture { get; set; }
        public object? coupon_amount { get; set; }
        public string description { get; set; }
        public object? differential_pricing_id { get; set; }
        public string? external_reference { get; set; }
        public int? installments { get; set; }
        public object? metadata { get; set; }
        public Payer? payer { get; set; }
        public string payment_method_id { get; set; }
        public string? token { get; set; }
        public double transaction_amount { get; set; }

        public class AdditionalInfo
        {
            public List<ItemDetail> items { get; set; }
            public Payer payer { get; set; }
            public Shipments shipments { get; set; }
        }

        public class Address
        {
            public object street_number { get; set; }
        }

        public class CategoryDescriptor
        {
            public Passenger passenger { get; set; }
            public Route route { get; set; }
        }

        public class Identification
        {
            public string type { get; set; }
            public string number { get; set; }
        }

        public class ItemDetail
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string picture_url { get; set; }
            public string category_id { get; set; }
            public int quantity { get; set; }
            public double unit_price { get; set; }
            public string type { get; set; }
            public DateTime event_date { get; set; }
            public bool warranty { get; set; }
            public CategoryDescriptor category_descriptor { get; set; }
        }

        public class Passenger
        {
        }

        public class Payer
        {
            public string? first_name { get; set; }
            public string? last_name { get; set; }
            public Phone? phone { get; set; }
            public Address? address { get; set; }
            public string? entity_type { get; set; }
            public string? type { get; set; }
            public object? id { get; set; }
            public string? email { get; set; }
            public Identification? identification { get; set; }
        }

        public class Phone
        {
            public int area_code { get; set; }
            public string number { get; set; }
        }

        public class ReceiverAddress
        {
            public string zip_code { get; set; }
            public string state_name { get; set; }
            public string city_name { get; set; }
            public string street_name { get; set; }
            public int street_number { get; set; }
        }

        public class Route
        {
        }

        public class Shipments
        {
            public ReceiverAddress receiver_address { get; set; }
            public object width { get; set; }
            public object height { get; set; }
        }
    }
}