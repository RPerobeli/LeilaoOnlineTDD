using System;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("valor de lance não pode ser negativo, nem cliente pode ser nulo");
            }
            Cliente = cliente;
            Valor = valor;
        }
    }
}
