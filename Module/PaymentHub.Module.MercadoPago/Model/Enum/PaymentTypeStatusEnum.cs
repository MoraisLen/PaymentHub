using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHub.MercadoPago.Model.Enum
{
    public enum PaymentTypeStatusEnum
    {
        cancelado = 1,
        aprovado = 2,
        pendente = 3
    }

    public enum PaymentTypeStatusConvertEnum
    {
        cancelled = 1,
        approved = 2,
        pending = 3
    }
}
