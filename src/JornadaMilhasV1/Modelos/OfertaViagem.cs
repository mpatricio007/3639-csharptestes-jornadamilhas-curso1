using JornadaMilhasV1.Validador;

namespace JornadaMilhasV1.Modelos;

public class OfertaViagem : Valida
{
    public int Id { get; set; }
    public Rota Rota { get; set; }
    public Periodo Periodo { get; set; }
    public double Preco { get; set; }


    public OfertaViagem(Rota rota, Periodo periodo, double preco)
    {
        Rota = rota;
        Periodo = periodo;
        Preco = preco;
        Validar();
    }

    public override string ToString()
    {
        return $"Origem: {Rota.Origem}, Destino: {Rota.Destino}, Data de Ida: {Periodo.DataInicial.ToShortDateString()}, Data de Volta: {Periodo.DataFinal.ToShortDateString()}, Preço: {Preco:C}";
    }

    protected override void Validar()
    {
        VerificarERegistrarErro(Periodo == null, ErrorMessages.PeriodoNull);
        VerificarERegistrarErro(Periodo != null && !Periodo.EhValido, Periodo?.Erros.Sumario);
        VerificarERegistrarErro(Rota == null, ErrorMessages.RotaNull);
        VerificarERegistrarErro(Preco <= 0, ErrorMessages.PrecoNegativo);
    }
}
