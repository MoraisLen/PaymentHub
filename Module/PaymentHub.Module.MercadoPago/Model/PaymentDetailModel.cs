namespace PaymentHub.MercadoPago.Model
{
    public class PaymentDetailModel
    {
        public long Id { get; set; }
        public double ValorTotal { get; set; }
        public string Descricao { get; set; }
        public string ReferenciaExterna { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public string Status { get; set; }
        public DadosPagadorInfo? Pagador { get; set; }
        public DadosRecebedor Recebedor { get; set; }
        public List<DadosProdutoInfo>? Produtos { get; set; }
        public string LinkPagamento { get; set; }
        public string CodigoCopiaECola { get; set; }
        public string QrCodeBase64 { get; set; }

        public class DadosPagadorInfo
        {
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public string Email { get; set; }
        }

        public class DadosProdutoInfo
        {
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public double ValorUnitario { get; set; }
            public int Quantidade { get; set; }
        }

        public class DadosRecebedor
        {
            public string Nome { get; set; }
        }
    }
}