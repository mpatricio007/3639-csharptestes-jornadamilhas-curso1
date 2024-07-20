using JornadaMilhasV1.Validador;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test.Modelos
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQaundoDadosValidos()
        {
            //Arrange
            const string strOrigem = "origem";
            const string strdestino = "destino";
            Rota rota = new Rota(strOrigem,strdestino);

            DateTime dtInicio = new DateTime(2024, 07, 19);
            DateTime dtFinal = new DateTime(2024, 07, 20);

            Periodo periodo = new Periodo(dtInicio, dtFinal);
            const double preco = 100.00;
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);

            //Act
            var result = ofertaViagem.EhValido;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void RetornaErroMessageRotaNullQuandoRotaNula()
        {
            //Arrange
            const string strOrigem = "origem";
            const string strdestino = "destino";
            Rota rota = null;

            DateTime dtInicio = new DateTime(2024, 07, 19);
            DateTime dtFinal = new DateTime(2024, 07, 20);

            Periodo periodo = new Periodo(dtInicio, dtFinal);
            const double preco = 100.00;
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);


            //Act
            var result = ofertaViagem.EhValido;

            //Assert
            Assert.Null(rota);
            Assert.Contains(ErrorMessages.RotaNull, ofertaViagem.Erros.Sumario);
            Assert.False(result);
        }

        [Fact]
        public void RetornaErroMessagePedidoComDataInicioMaiorQueDataFinalQuandoPeriodoInvalido()
        {
            //Arrange
            const string strOrigem = "origem";
            const string strdestino = "destino";
            Rota rota = new Rota(strOrigem, strdestino);

            DateTime dtInicio = new DateTime(2024, 07, 19);
            DateTime dtFinal = new DateTime(2024, 07, 18);

            Periodo periodo = new Periodo(dtInicio, dtFinal);
            const double preco = 100.00;
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);


            //Act
            var result = ofertaViagem.EhValido;

            //Assert            
            Assert.Contains(ErrorMessages.PedidoComDataInicioMaiorQueDataFinal, ofertaViagem.Erros.Sumario);
            Assert.False(result);
        }

        [Fact]
        public void RetornaErroMessagePrecoNegativoQuandoPrecoMenorQueZero()
        {
            //Arrange
            const string strOrigem = "origem";
            const string strdestino = "destino";
            Rota rota = new Rota(strOrigem, strdestino);

            DateTime dtInicio = new DateTime(2024, 07, 19);
            DateTime dtFinal = new DateTime(2024, 07, 20);

            Periodo periodo = new Periodo(dtInicio, dtFinal);
            const double preco = -100.00;
            OfertaViagem ofertaViagem = new OfertaViagem(rota, periodo, preco);

            //Act
            var result = ofertaViagem.EhValido;

            //Assert            
            Assert.Contains(ErrorMessages.PrecoNegativo, ofertaViagem.Erros.Sumario);
            Assert.False(result);
        }
    }
}