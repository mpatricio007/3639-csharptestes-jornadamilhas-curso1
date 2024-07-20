using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV1.Validador;

internal class ErrorMessages
{
    public const string RotaOrPeriodoNull  = "A oferta de viagem não possui rota ou período válidos.";

    public const string PedidoComDataInicioMaiorQueDataFinal  = "Erro: Data de ida não pode ser maior que a data de volta.";

    public const string PrecoNegativo = "O preço da oferta de viagem deve ser maior que zero.";
}

