namespace PaymentHub.MercadoPago.HttpRequest.Request.CreatePayment
{
    public class CreatePaymentResponse
    {
        public long id { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_of_expiration { get; set; }
        public DateTime? date_approved { get; set; }
        public DateTime date_last_updated { get; set; }
        public DateTime? money_release_date { get; set; }
        public int issuer_id { get; set; }
        public string payment_method_id { get; set; }
        public string payment_type_id { get; set; }
        public string status { get; set; }
        public string status_detail { get; set; }
        public string currency_id { get; set; }
        public string description { get; set; }
        public int taxes_amount { get; set; }
        public int shipping_amount { get; set; }
        public int collector_id { get; set; }
        public Payer payer { get; set; }
        public Metadata metadata { get; set; }
        public AdditionalInfo additional_info { get; set; }
        public string external_reference { get; set; }
        public double transaction_amount { get; set; }
        public int transaction_amount_refunded { get; set; }
        public int coupon_amount { get; set; }
        public TransactionDetails transaction_details { get; set; }
        public List<FeeDetail> fee_details { get; set; }
        public string statement_descriptor { get; set; }
        public int installments { get; set; }
        public Card card { get; set; }
        public string notification_url { get; set; }
        public string processing_mode { get; set; }
        public PointOfInteraction point_of_interaction { get; set; }

        public class Shipments
        {
            public ReceiverAddress receiver_address { get; set; }
        }
        public class BankInfo
        {
            public Collector collector { get; set; }
            public object is_same_bank_account_owner { get; set; }
            public object origin_bank_id { get; set; }
            public object origin_wallet_id { get; set; }
        }

        public class Collector
        {
            public string account_holder_name { get; set; }
            public object account_id { get; set; }
            public object long_name { get; set; }
            public object transfer_account_id { get; set; }
        }

        public class TransactionData
        {
            public BankInfo bank_info { get; set; }
            public object bank_transfer_id { get; set; }
            public object e2e_id { get; set; }
            public object financial_institution { get; set; }
            public string qr_code { get; set; }
            public string qr_code_base64 { get; set; }
            public string ticket_url { get; set; }
            public object transaction_id { get; set; }
        }

        public class TransactionDetails
        {
            public double net_received_amount { get; set; }
            public double total_paid_amount { get; set; }
            public int overpaid_amount { get; set; }
            public double installment_amount { get; set; }
        }

        public class AdditionalInfo
        {
            public List<Item> items { get; set; }
            public Payer payer { get; set; }
            public Shipments shipments { get; set; }
        }

        public class ApplicationData
        {
            public string name { get; set; }
            public string version { get; set; }
        }

        public class Card
        {
            public int first_six_digits { get; set; }
            public int last_four_digits { get; set; }
            public int expiration_month { get; set; }
            public int expiration_year { get; set; }
            public DateTime date_created { get; set; }
            public DateTime date_last_updated { get; set; }
            public Cardholder cardholder { get; set; }
        }

        public class Cardholder
        {
            public string name { get; set; }
            public Identification identification { get; set; }
        }

        public class FeeDetail
        {
            public string type { get; set; }
            public double amount { get; set; }
            public string fee_payer { get; set; }
        }

        public class Identification
        {
            public long? number { get; set; }
            public string type { get; set; }
        }

        public class Item
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string picture_url { get; set; }
            public string category_id { get; set; }
            public int quantity { get; set; }
            public double unit_price { get; set; }
        }

        public class Metadata
        {
        }

        public class Payer
        {
            public long id { get; set; }
            public string email { get; set; }
            public Identification identification { get; set; }
            public string type { get; set; }
            public DateTime registration_date { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
        }

        public class PointOfInteraction
        {
            public string type { get; set; }
            public ApplicationData application_data { get; set; }
            public TransactionData transaction_data { get; set; }
        }

        public class ReceiverAddress
        {
            public string street_name { get; set; }
            public int street_number { get; set; }
            public int zip_code { get; set; }
            public string city_name { get; set; }
            public string state_name { get; set; }
        }
    }

    
}