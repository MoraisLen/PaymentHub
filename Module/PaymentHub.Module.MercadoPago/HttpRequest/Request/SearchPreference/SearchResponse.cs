using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHub.MercadoPago.HttpRequest.Request.SearchPreference
{
    public class Element
    {
        public string id { get; set; }
        public string client_id { get; set; }
        public int collector_id { get; set; }
        public object concept_id { get; set; }
        public string corporation_id { get; set; }
        public DateTime date_created { get; set; }
        public DateTime? expiration_date_from { get; set; }
        public DateTime? expiration_date_to { get; set; }
        public bool expires { get; set; }
        public string external_reference { get; set; }
        public string integrator_id { get; set; }
        public List<string> items { get; set; }
        public object last_updated { get; set; }
        public bool live_mode { get; set; }
        public string marketplace { get; set; }
        public string operation_type { get; set; }
        public string payer_email { get; set; }
        public object payer_id { get; set; }
        public string platform_id { get; set; }
        public object processing_modes { get; set; }
        public string product_id { get; set; }
        public string purpose { get; set; }
        public string site_id { get; set; }
        public int sponsor_id { get; set; }
        public string shipping_mode { get; set; }
    }

    public class SearchResponse
    {
        public List<Element> elements { get; set; }
        public int next_offset { get; set; }
        public int total { get; set; }
    }
}


