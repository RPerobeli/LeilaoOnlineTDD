using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; private set; }
        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            ValorDestino = valorDestino;
        }
        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances.Where(l => l.Valor > ValorDestino).OrderBy(l => l.Valor).FirstOrDefault();
        }
    }
}
