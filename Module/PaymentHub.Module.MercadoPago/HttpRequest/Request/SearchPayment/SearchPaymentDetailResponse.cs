using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHub.MercadoPago.HttpRequest.Request.SearchPayment
{
    public class SearchPaymentDetailResponse
    {
        public string accounts_info { get; set; }
        public List<string> acquirer_reconciliation { get; set; }
        public AdditionalInfo additional_info { get; set; }
        public string authorization_code { get; set; }
        public bool binary_mode { get; set; }
        public string brand_id { get; set; }
        public string build_version { get; set; }
        public string call_for_authorize_id { get; set; }
        public string callback_url { get; set; }
        public bool captured { get; set; }
        public Card card { get; set; }
        public List<ChargesDetail> charges_details { get; set; }
        public int collector_id { get; set; }
        public string corporation_id { get; set; }
        public string counter_currency { get; set; }
        public int coupon_amount { get; set; }
        public string currency_id { get; set; }
        public DateTime? date_approved { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_last_updated { get; set; }
        public DateTime date_of_expiration { get; set; }
        public string deduction_schema { get; set; }
        public string description { get; set; }
        public string differential_pricing_id { get; set; }
        public string external_reference { get; set; }
        public List<string> fee_details { get; set; }
        public string financing_group { get; set; }
        public long id { get; set; }
        public int installments { get; set; }
        public string integrator_id { get; set; }
        public string issuer_id { get; set; }
        public bool live_mode { get; set; }
        public string marketplace_owner { get; set; }
        public string merchant_account_id { get; set; }
        public string merchant_number { get; set; }
        public Metadata metadata { get; set; }
        public string money_release_date { get; set; }
        public string money_release_schema { get; set; }
        public string money_release_status { get; set; }
        public string notification_url { get; set; }
        public string operation_type { get; set; }
        public Order order { get; set; }
        public Payer payer { get; set; }
        public PaymentMethod payment_method { get; set; }
        public string payment_method_id { get; set; }
        public string payment_type_id { get; set; }
        public string platform_id { get; set; }
        public PointOfInteraction point_of_interaction { get; set; }
        public string pos_id { get; set; }
        public string processing_mode { get; set; }
        public List<string> refunds { get; set; }
        public int shipping_amount { get; set; }
        public string sponsor_id { get; set; }
        public string statement_descriptor { get; set; }
        public string status { get; set; }
        public string status_detail { get; set; }
        public string store_id { get; set; }
        public string tags { get; set; }
        public int taxes_amount { get; set; }
        public double transaction_amount { get; set; }
        public int transaction_amount_refunded { get; set; }
        public TransactionDetails transaction_details { get; set; }

        public class Accounts
        {
            public string from { get; set; }
            public string to { get; set; }
        }

        public class AdditionalInfo
        {
            public string authentication_code { get; set; }
            public string available_balance { get; set; }
            public string nsu_processadora { get; set; }
        }

        public class Amounts
        {
            public double original { get; set; }
            public int refunded { get; set; }
        }

        public class ApplicationData
        {
            public string name { get; set; }
            public string version { get; set; }
        }

        public class BankInfo
        {
            public Collector collector { get; set; }
            public string is_same_bank_account_owner { get; set; }
            public string origin_bank_id { get; set; }
            public string origin_wallet_id { get; set; }
            public Payer payer { get; set; }
        }

        public class BusinessInfo
        {
            public string branch { get; set; }
            public string sub_unit { get; set; }
            public string unit { get; set; }
        }

        public class Card
        {
        }

        public class ChargesDetail
        {
            public Accounts accounts { get; set; }
            public Amounts amounts { get; set; }
            public int client_id { get; set; }
            public DateTime date_created { get; set; }
            public string id { get; set; }
            public DateTime last_updated { get; set; }
            public Metadata metadata { get; set; }
            public string name { get; set; }
            public List<string> refund_charges { get; set; }
            public string reserve_id { get; set; }
            public string type { get; set; }
        }

        public class Collector
        {
            public string account_holder_name { get; set; }
            public string account_id { get; set; }
            public string long_name { get; set; }
            public string transfer_account_id { get; set; }
        }

        public class Identification
        {
            public string number { get; set; }
            public string type { get; set; }
        }

        public class InfringementNotification
        {
            public string status { get; set; }
            public string type { get; set; }
        }

        public class Location
        {
            public string source { get; set; }
            public string state_id { get; set; }
        }

        public class Metadata
        {
        }

        public class Order
        {
        }

        public class Payer
        {
            public string email { get; set; }
            public string entity_type { get; set; }
            public string first_name { get; set; }
            public string id { get; set; }
            public Identification identification { get; set; }
            public string last_name { get; set; }
            public string operator_id { get; set; }
            public Phone phone { get; set; }
            public string type { get; set; }
            public string account_id { get; set; }
            public string external_account_id { get; set; }
            public string long_name { get; set; }
        }

        public class PaymentMethod
        {
            public string id { get; set; }
            public string issuer_id { get; set; }
            public string type { get; set; }
        }

        public class Phone
        {
            public string number { get; set; }
            public string extension { get; set; }
            public string area_code { get; set; }
        }

        public class PointOfInteraction
        {
            public ApplicationData application_data { get; set; }
            public BusinessInfo business_info { get; set; }
            public Location location { get; set; }
            public TransactionData transaction_data { get; set; }
            public string type { get; set; }
        }

        public class TransactionData
        {
            public BankInfo bank_info { get; set; }
            public string bank_transfer_id { get; set; }
            public string e2e_id { get; set; }
            public string financial_institution { get; set; }
            public InfringementNotification infringement_notification { get; set; }
            public string qr_code { get; set; }
            public string qr_code_base64 { get; set; }
            public string ticket_url { get; set; }
            public string transaction_id { get; set; }
        }

        public class TransactionDetails
        {
            public string acquirer_reference { get; set; }
            public string bank_transfer_id { get; set; }
            public string external_resource_url { get; set; }
            public string financial_institution { get; set; }
            public int installment_amount { get; set; }
            public int net_received_amount { get; set; }
            public int overpaid_amount { get; set; }
            public string payable_deferral_period { get; set; }
            public string payment_method_reference_id { get; set; }
            public double total_paid_amount { get; set; }
            public string transaction_id { get; set; }
        }
    }
}
