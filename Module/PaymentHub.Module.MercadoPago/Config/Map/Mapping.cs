using PaymentHub.MercadoPago.HttpRequest.Request.CreatePayment;
using PaymentHub.MercadoPago.HttpRequest.Request.CreatePreference;
using PaymentHub.MercadoPago.HttpRequest.Request.PaymentMethod;
using PaymentHub.MercadoPago.HttpRequest.Request.SearchPayment;
using PaymentHub.MercadoPago.HttpRequest.Request.SearchPreference;
using PaymentHub.MercadoPago.Model;
using PaymentHub.MercadoPago.Model.Enum;

namespace PaymentHub.MercadoPago.Config.Map
{
    public class Mapping
    {
        public static CreatePreferenceRequest CreatePreferenceRequest(PreferenceModel entidade)
        {
            return new CreatePreferenceRequest
            {
                additional_info = entidade.Observacao,
                expiration_date_from = entidade.DataMinPagamento,
                expiration_date_to = entidade.DataVencimento,
                expires = entidade.FlExpira,
                items = entidade.Itens.Select(i => new CreatePreferenceRequest.Item
                {
                    id = i.Id,
                    title = i.Titulo,
                    description = i.Descricao,
                    picture_url = i.UrlImagem,
                    quantity = i.Quantidade,
                    currency_id = i.Moeda,
                    unit_price = i.PrecoUnitario
                }).ToList(),
                payer = new CreatePreferenceRequest.Payer
                {
                    name = entidade.Pagador.Nome,
                    surname = entidade.Pagador.Sobrenome,
                    email = entidade.Pagador.Email,
                    identification = new CreatePreferenceRequest.Identification
                    {
                        type = "CPF",
                        number = entidade.Pagador.CPF
                    },
                    date_created = entidade.Pagador.DataCriacao
                },
                payment_methods = new CreatePreferenceRequest.PaymentMethods
                {
                    excluded_payment_methods = entidade.MetodoPagamento.MetodosPagamentoExcluidos.Select(epm => new CreatePreferenceRequest.ExcludedPaymentMethod
                    {
                        id = epm.Id
                    }).ToList(),
                    excluded_payment_types = entidade.MetodoPagamento.TiposPagamentoExcluidos.Select(ept => new CreatePreferenceRequest.ExcludedPaymentType
                    {
                        id = ept.Id
                    }).ToList(),
                    default_payment_method_id = entidade.MetodoPagamento.MetodoPagamentoPadrao
                }
            };
        }

        public static PreferenceModel PreferenceModel(CreatePreferenceResponse entidade)
        {
            return new PreferenceModel
            {
                DataCriacao = entidade.date_created,
                DataMinPagamento = entidade.expiration_date_from,
                DataVencimento = entidade.expiration_date_to,
                Itens = entidade.items?.Select(x => new PreferenceModel.Item
                {
                    Titulo = x.title,
                    Descricao = x.description,
                    Moeda = x.currency_id,
                    PrecoUnitario = x.unit_price,
                    Quantidade = x.quantity
                }).ToList() ?? new List<PreferenceModel.Item>(),
                Id = entidade.id,
                LinkPagamento = entidade.init_point
            };
        }

        public static List<PreferenceItemModel> SearchPreferenceResponse(SearchResponse search)
        {
            return search.elements.Select(src => new PreferenceItemModel
            {
                Id = src.id,
                IdCliente = src.client_id,
                DataCriacao = src.date_created,
                DataMinPagamento = src.expiration_date_from,
                DataVencimento = src.expiration_date_to,
                EmailPagador = src.payer_email,
                Itens = src.items
            }).ToList();
        }

        public static List<PaymentMethodModel> PaymentMethodModelList(List<PaymentMethodResponse> lstMethod)
        {
            return lstMethod.Select(x => new PaymentMethodModel
            {
                IdPagamento = x.id,
                IdTipoPagamento = x.payment_type_id,
                NomePagamento = x.name
            }).ToList();
        }

        public static CreatePaymentRequest CreatePaymentRequest(PaymentModel payment, PaymentTypeEnum paymentType = PaymentTypeEnum.PIX)
        {
            CreatePaymentRequest dest = new CreatePaymentRequest
            {
                description = payment.Descricao,
                external_reference = payment.ReferenciaExterna,
                payer = payment.Pagador != null ? new CreatePaymentRequest.Payer
                {
                    first_name = payment.Pagador.Nome,
                    last_name = payment.Pagador.Sobrenome,
                    email = payment.Pagador.Email
                }
                : null,
                transaction_amount = payment.ValorTotal,
                additional_info = payment.Produtos != null ? new CreatePaymentRequest.AdditionalInfo
                {
                    items = payment.Produtos.Select(x => new CreatePaymentRequest.ItemDetail
                    {
                        title = x.Nome,
                        description = x.Descricao,
                        unit_price = x.ValorUnitario,
                        quantity = x.Quantidade
                    }).ToList(),
                }
                : null
            };

            switch (paymentType)
            {
                case PaymentTypeEnum.PIX:
                    dest.payment_method_id = "pix";
                    break;
            }

            return dest;
        }

        public static PaymentDetailModel PaymentDetailModel(CreatePaymentResponse payment)
        {
            return new PaymentDetailModel
            {
                Id = payment.id,
                ValorTotal = payment.transaction_amount,
                DataCriacao = payment.date_created,
                DataExpiracao = payment.date_of_expiration,
                DataAprovacao = payment.date_approved,
                Pagador = new PaymentDetailModel.DadosPagadorInfo
                {
                    Nome = payment.payer.first_name,
                    Sobrenome = payment.payer.last_name,
                    Email = payment.payer.email
                },
                Recebedor = new PaymentDetailModel.DadosRecebedor
                {
                    Nome = payment.point_of_interaction.transaction_data.bank_info.collector.account_holder_name
                },
                Produtos = payment.additional_info.items?.Select(x => new PaymentDetailModel.DadosProdutoInfo
                {
                    Nome = x.title,
                    Descricao = x.description,
                    ValorUnitario = x.unit_price,
                    Quantidade = x.quantity
                }).ToList(),
                Status = payment.status,
                Descricao = payment.description,
                ReferenciaExterna = payment.external_reference,
                CodigoCopiaECola = payment.point_of_interaction.transaction_data.qr_code,
                LinkPagamento = payment.point_of_interaction.transaction_data.ticket_url,
                QrCodeBase64 = payment.point_of_interaction.transaction_data.qr_code_base64
            };
        }

        public static List<PaymentDetailModel> PaymentDetailModelList(SearchPaymentResponse payment)
        {
            return payment.results != null
            ? payment.results.Select(x => new PaymentDetailModel
            {
                Id = x.id,
                ValorTotal = x.transaction_amount,
                DataCriacao = x.date_created,
                DataExpiracao = x.date_of_expiration,
                DataAprovacao = x.date_approved,
                Status = x.status,
                Descricao = x.description,
                ReferenciaExterna = x.external_reference,
                CodigoCopiaECola = x.point_of_interaction?.transaction_data?.qr_code,
                LinkPagamento = x.point_of_interaction.transaction_data?.ticket_url,
                QrCodeBase64 = x.point_of_interaction.transaction_data?.qr_code_base64
            }).ToList()
            : new List<PaymentDetailModel>();
        }

        public static PaymentDetailModel PaymentDetailModel(SearchPaymentDetailResponse payment)
        {
            return new PaymentDetailModel
            {
                Id = payment.id,
                ValorTotal = payment.transaction_amount,
                DataCriacao = payment.date_created,
                DataExpiracao = payment.date_of_expiration,
                DataAprovacao = payment.date_approved,
                Status = payment.status,
                Descricao = payment.description,
                ReferenciaExterna = payment.external_reference,
                CodigoCopiaECola = payment.point_of_interaction.transaction_data.qr_code,
                LinkPagamento = payment.point_of_interaction.transaction_data.ticket_url,
                QrCodeBase64 = payment.point_of_interaction.transaction_data.qr_code_base64
            };
        }
    }
}