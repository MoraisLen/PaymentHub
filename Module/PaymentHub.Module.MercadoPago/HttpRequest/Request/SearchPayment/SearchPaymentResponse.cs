using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHub.MercadoPago.HttpRequest.Request.SearchPayment
{
    // Root myDeserializedClass = JsonConvert.Deserializestring<Root>(myJsonResponse);
    public class Accounts
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class AdditionalInfo
    {
        public string authentication_code { get; set; }
        public string nsu_processadora { get; set; }
        public string available_balance { get; set; }
        public List<Item> items { get; set; }
        public string ip_address { get; set; }
        public BankInfo bank_info { get; set; }
    }

    public class Amounts
    {
        public double original { get; set; }
        public double refunded { get; set; }
    }

    public class ApplicationData
    {
        public string name { get; set; }
        public string version { get; set; }
    }

    public class BankInfo
    {
        public string origin_wallet_id { get; set; }
        public bool? is_same_bank_account_owner { get; set; }
        public string origin_bank_id { get; set; }
        public Payer payer { get; set; }
        public Collector collector { get; set; }
    }

    public class BusinessInfo
    {
        public string unit { get; set; }
        public string sub_unit { get; set; }
    }

    public class Card
    {
        public string first_six_digits { get; set; }
        public int expiration_year { get; set; }
        public string bin { get; set; }
        public DateTime date_created { get; set; }
        public int expiration_month { get; set; }
        public string id { get; set; }
        public Cardholder cardholder { get; set; }
        public string last_four_digits { get; set; }
        public DateTime date_last_updated { get; set; }
    }

    public class Cardholder
    {
        public Identification identification { get; set; }
        public string name { get; set; }
    }

    public class ChargesDetail
    {
        public List<RefundCharge> refund_charges { get; set; }
        public DateTime last_updated { get; set; }
        public Metadata metadata { get; set; }
        public Amounts amounts { get; set; }
        public DateTime date_created { get; set; }
        public string name { get; set; }
        public long? reserve_id { get; set; }
        public Accounts accounts { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string client_id { get; set; }
    }

    public class Collector
    {
        public string account_id { get; set; }
        public string account_holder_name { get; set; }
        public string long_name { get; set; }
        public string transfer_account_id { get; set; }
        public Identification identification { get; set; }
        public string phone { get; set; }
        public string operator_id { get; set; }
        public string last_name { get; set; }
        public int id { get; set; }
        public string first_name { get; set; }
        public string email { get; set; }
    }

    public class Coverage
    {
        public int id { get; set; }
        public string client_id { get; set; }
        public string flow { get; set; }
    }

    public class Data
    {
        public string retried_by { get; set; }
        public RoutingData routing_data { get; set; }
    }

    public class Expanded
    {
        public Gateway gateway { get; set; }
    }

    public class FeeDetail
    {
        public double amount { get; set; }
        public string fee_payer { get; set; }
        public string type { get; set; }
    }

    public class Gateway
    {
        public double buyer_fee { get; set; }
        public double finance_charge { get; set; }
        public DateTime date_created { get; set; }
        public string merchant { get; set; }
        public string reference { get; set; }
        public string statement_descriptor { get; set; }
        public string issuer_id { get; set; }
        public string usn { get; set; }
        public int installments { get; set; }
        public string soft_descriptor { get; set; }
        public string authorization_code { get; set; }
        public string payment_id { get; set; }
        public string profile_id { get; set; }
        public string options { get; set; }
        public string connection { get; set; }
        public string id { get; set; }
        public string operation { get; set; }
    }

    public class Identification
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class InfringementNotification
    {
        public string type { get; set; }
        public string status { get; set; }
    }

    public class InvoicePeriod
    {
        public int period { get; set; }
        public string type { get; set; }
    }

    public class Item
    {
        public string quantity { get; set; }
        public string category_id { get; set; }
        public string picture_url { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string unit_price { get; set; }
    }

    public class Location
    {
        public string source { get; set; }
        public string state_id { get; set; }
    }

    public class Metadata
    {
        public int? official_store_id { get; set; }
        public DateTime? payments_group_timestamp { get; set; }
        public int? payments_group_size { get; set; }
        public string payments_group_uuid { get; set; }
        public long? shipment_id { get; set; }
        public string meli_campaign { get; set; }
        public long? coupon_id { get; set; }
        public string item_id { get; set; }
        public string coupon_fee { get; set; }
        public string campaign_marketplace { get; set; }
        public string campaign_type { get; set; }
        public long? campaign_id { get; set; }
        public string items_group { get; set; }
        public long? variation { get; set; }
        public string idempotency_key { get; set; }
        public Coverage coverage { get; set; }
        public string status_detail { get; set; }
    }

    public class Operation
    {
        public int id { get; set; }
        public string type { get; set; }
    }

    public class Order
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Paging
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

    public class Payer
    {
        public int? account_id { get; set; }
        public string external_account_id { get; set; }
        public string id { get; set; }
        public string long_name { get; set; }
        public Identification identification { get; set; }
    }

    public class PaymentMethod
    {
        public Data data { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string issuer_id { get; set; }
    }

    public class PaymentReference
    {
        public string id { get; set; }
        public string acquirer { get; set; }
    }

    public class PointOfInteraction
    {
        public BusinessInfo business_info { get; set; }
        public TransactionData transaction_data { get; set; }
        public string type { get; set; }
        public ApplicationData application_data { get; set; }
        public Location location { get; set; }
        public string sub_type { get; set; }
    }

    public class Refund
    {
        public string funder { get; set; }
        public string alternative_refund_mode { get; set; }
        public string reason { get; set; }
        public Metadata metadata { get; set; }
        public Source source { get; set; }
        public string expiration_date { get; set; }
        public List<string> partition_details { get; set; }
        public double amount_refunded_to_payer { get; set; }
        public long payment_id { get; set; }
        public int id { get; set; }
        public double amount { get; set; }
        public DateTime date_created { get; set; }
        public string external_refund_id { get; set; }
        public string unique_sequence_number { get; set; }
        public List<string> labels { get; set; }
        public string additional_data { get; set; }
        public string refund_mode { get; set; }
        public int adjustment_amount { get; set; }
        public List<string> external_operations { get; set; }
        public string status { get; set; }
    }

    public class RefundCharge
    {
        public double amount { get; set; }
        public DateTime date_created { get; set; }
        public string reserve_id { get; set; }
        public Operation operation { get; set; }
        public string client_id { get; set; }
        public string currency_id { get; set; }
    }

    public class Result
    {
        public Metadata metadata { get; set; }
        public string corporation_id { get; set; }
        public string operation_type { get; set; }
        public PointOfInteraction point_of_interaction { get; set; }
        public List<FeeDetail> fee_details { get; set; }
        public string notification_url { get; set; }
        public DateTime? date_approved { get; set; }
        public string money_release_schema { get; set; }
        public TransactionDetails transaction_details { get; set; }
        public string statement_descriptor { get; set; }
        public string call_for_authorize_id { get; set; }
        public int installments { get; set; }
        public string pos_id { get; set; }
        public string external_reference { get; set; }
        public DateTime? date_of_expiration { get; set; }
        public List<ChargesDetail> charges_details { get; set; }
        public long id { get; set; }
        public string payment_type_id { get; set; }
        public PaymentMethod payment_method { get; set; }
        public Order order { get; set; }
        public string counter_currency { get; set; }
        public string money_release_status { get; set; }
        public string brand_id { get; set; }
        public string status_detail { get; set; }
        public int? differential_pricing_id { get; set; }
        public AdditionalInfo additional_info { get; set; }
        public bool live_mode { get; set; }
        public int payer_id { get; set; }
        public string marketplace_owner { get; set; }
        public Card card { get; set; }
        public string integrator_id { get; set; }
        public string status { get; set; }
        public double transaction_amount_refunded { get; set; }
        public double transaction_amount { get; set; }
        public string description { get; set; }
        public string financing_group { get; set; }
        public DateTime? money_release_date { get; set; }
        public string merchant_number { get; set; }
        public Collector collector { get; set; }
        public List<Refund> refunds { get; set; }
        public Expanded expanded { get; set; }
        public string authorization_code { get; set; }
        public bool captured { get; set; }
        public string merchant_account_id { get; set; }
        public int taxes_amount { get; set; }
        public DateTime date_last_updated { get; set; }
        public double coupon_amount { get; set; }
        public string store_id { get; set; }
        public string build_version { get; set; }
        public DateTime date_created { get; set; }
        public List<string> acquirer_reconciliation { get; set; }
        public string sponsor_id { get; set; }
        public double shipping_amount { get; set; }
        public string issuer_id { get; set; }
        public string payment_method_id { get; set; }
        public bool binary_mode { get; set; }
        public string platform_id { get; set; }
        public string deduction_schema { get; set; }
        public string processing_mode { get; set; }
        public string currency_id { get; set; }
        public double shipping_cost { get; set; }
        public string tags { get; set; }
        public string accounts_info { get; set; }
        public string callback_url { get; set; }
    }

    public class SearchPaymentResponse
    {
        public List<Result> results { get; set; }
        public Paging paging { get; set; }
    }

    public class RoutingData
    {
        public string merchant_account_id { get; set; }
    }

    public class Source
    {
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class SubscriptionSequence
    {
        public int number { get; set; }
        public string total { get; set; }
    }

    public class TransactionData
    {
        public string subscription_id { get; set; }
        public InvoicePeriod invoice_period { get; set; }
        public SubscriptionSequence subscription_sequence { get; set; }
        public bool first_time_use { get; set; }
        public string invoice_id { get; set; }
        public string billing_date { get; set; }
        public PaymentReference payment_reference { get; set; }
        public string processor { get; set; }
        public string plan_id { get; set; }
        public string e2e_id { get; set; }
        public string user_present { get; set; }
        public string transaction_id { get; set; }
        public BankInfo bank_info { get; set; }
        public InfringementNotification infringement_notification { get; set; }
        public long? bank_transfer_id { get; set; }
        public int? financial_institution { get; set; }
        public string qr_code { get; set; }
        public string ticket_url { get; set; }
        public string qr_code_base64 { get; set; }
    }

    public class TransactionDetails
    {
        public double total_paid_amount { get; set; }
        public string acquirer_reference { get; set; }
        public double installment_amount { get; set; }
        public string financial_institution { get; set; }
        public double net_received_amount { get; set; }
        public int overpaid_amount { get; set; }
        public string external_resource_url { get; set; }
        public string payable_deferral_period { get; set; }
        public string payment_method_reference_id { get; set; }
        public string transaction_id { get; set; }
        public long? bank_transfer_id { get; set; }
    }


}
