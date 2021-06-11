using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProxLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            Interessada fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano,800);

            //Act
            leilao.RecebeLance(fulano, 2000);
            //Assert
            var qtdEsperada = 1;
            var valorObtido = leilao.Lances.Count();

            //Verificar(valorEsperado, valorObtido);
            Assert.Equal(qtdEsperada, valorObtido);
        }
        [Theory]
        [InlineData(2, new double[] { 800,900})]
        public void NaoPermiteNovosLancesSeLeilaoFinalizado(int qtdEsperada, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            Interessada fulano = new Interessada("Fulano", leilao);
            Interessada maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();
            for (int i=0;i<ofertas.Length;i++)
            {
                double valor = ofertas[i];
                if(i%2 == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }
            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(fulano, 2000);
            //Assert
            var valorObtido = leilao.Lances.Count();

            //Verificar(valorEsperado, valorObtido);
            Assert.Equal(qtdEsperada, valorObtido);
        }
    }
}
