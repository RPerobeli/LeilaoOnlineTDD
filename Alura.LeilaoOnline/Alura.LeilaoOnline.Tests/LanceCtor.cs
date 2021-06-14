using System;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arrange
            double valorNegativo = -100;
            Interessada cliente = new Interessada("cliente", null);

            //Assert
            Assert.Throws<ArgumentException>(
                //Act
                () => new Lance(cliente, valorNegativo)
                );
        }
    }
}
