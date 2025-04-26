namespace PaymentHub.MercadoPago.Model
{
    public class PaymentModel
    {
        public double ValorTotal { get; set; }
        public string Descricao { get; set; }
        public string ReferenciaExterna { get; set; }
        public DadosPagador? Pagador { get; set; }
        public List<DadosProduto>? Produtos { get; set; }

        public class DadosPagador
        {
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public string Email { get; set; }
        }

        public class DadosProduto
        {
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public double ValorUnitario { get; set; }
            public int Quantidade { get; set; }
        }
    }
}