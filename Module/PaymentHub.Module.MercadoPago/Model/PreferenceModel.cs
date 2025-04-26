namespace PaymentHub.MercadoPago.Model
{
    public class PreferenceModel
    {
        public string? Id { get; set; }
        public PagadorDetail Pagador { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataMinPagamento { get; set; }
        public DateTime? DataVencimento { get; set; }
        public bool FlExpira { get; set; }
        public List<Item> Itens { get; set; }
        public MetodoPagamentoDetail MetodoPagamento { get; set; }
        public string Observacao { get; set; }
        public string? LinkPagamento { get; set; }

        public class Item
        {
            public string Id { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string UrlImagem { get; set; }
            public int Quantidade { get; set; }
            public string Moeda { get; set; }
            public decimal PrecoUnitario { get; set; }
        }

        public class PagadorDetail
        {
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public string Email { get; set; }
            public string CPF { get; set; }
            public DateTime DataCriacao { get; set; }
        }

        public class MetodoPagamentoDetail
        {
            public List<MetodoExcluido> MetodosPagamentoExcluidos { get; set; }
            public List<TipoPagamentoExcluido> TiposPagamentoExcluidos { get; set; }
            public string MetodoPagamentoPadrao { get; set; }
        }

        public class MetodoExcluido
        {
            public string Id { get; set; }
        }

        public class TipoPagamentoExcluido
        {
            public string Id { get; set; }
        }
    }
}