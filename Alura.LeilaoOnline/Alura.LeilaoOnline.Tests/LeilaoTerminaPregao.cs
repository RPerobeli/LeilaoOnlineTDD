using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{

    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, new double[] {800,900,1000,1200})]
        [InlineData(800, new double[] {800})]
        [InlineData(1000, new double[] {800, 900, 1000, 990})]
        public void RetornaMaiorValorComPeloMenosUmLance(double esperado, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                double valor = ofertas[i];
                if (i % 2 == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;

            //Verificar(valorEsperado, valorObtido);
            Assert.Equal(esperado, valorObtido);
        }
        
        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
    
            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            //Verificar(valorEsperado, valorObtido);
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
