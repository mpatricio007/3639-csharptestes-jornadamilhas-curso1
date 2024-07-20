using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test.Modelos
{
    public class MusicaTest
    {
        [Fact]
        public void TestandoMusicaNomeValido()
        {
            //Arrange
            string nomeMusica = "nomeMusica";
            //Act
            Musica musica = new Musica(nomeMusica);


            //Assert
            Assert.NotNull(musica.Nome);
            Assert.Equal(nomeMusica, musica.Nome);            
        }

        [Fact]
        public void TestandoMusicaIdValido()
        {
            //Arrange
            int idMusica = 10;
            string nomeMusica = "nomeMusica";

            //Act
            Musica musica = new Musica(nomeMusica)
            {
                Id = idMusica
            };

            //Assert

            Assert.Equal(idMusica, musica.Id);
        }

        [Fact]
        public void TestandoMusicaToString()
        {
            //Arrange
            int idMusica = 10;
            string nomeMusica = "nomeMusica";

            string toStringEsperado = @$"Id: {idMusica} Nome: {nomeMusica}";

            Musica musica = new Musica(nomeMusica)
            {
                Id = idMusica
            };
            //Act

            string result = musica.ToString();

            //Assert

            Assert.Equal(toStringEsperado, result);
        }

    }
}
