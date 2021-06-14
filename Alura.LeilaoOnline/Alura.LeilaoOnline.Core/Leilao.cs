using System.Collections.Generic;
using System.Linq;
using System;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        private IModalidadeAvaliacao Modalidade;
        public IEnumerable<Lance> Lances => _lances;
        public enum EstadoLeilao
        {
            LeilaoAntesDoPregao,
            LeilaoEmAndamento,
            LeilaoFinalizado
        }
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }
        public Interessada UltimoCliente { get; private set; }
        public Leilao(string peca, IModalidadeAvaliacao modalidade)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
            Modalidade = modalidade;
        }

        public bool isNovoLanceAceito(Interessada cliente)
        {
            return(Estado == EstadoLeilao.LeilaoEmAndamento && cliente != UltimoCliente);
        }
        public void RecebeLance(Interessada cliente, double valor)
        {
            if(isNovoLanceAceito(cliente))
            {
                _lances.Add(new Lance(cliente, valor));
                UltimoCliente = cliente;
            }
            
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if(Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                throw new InvalidOperationException();
            }
            //Modalidade maior valor
            Ganhador = Modalidade.Avalia(this);
            //Ganhador = Lances.DefaultIfEmpty(new Lance(null,0)).OrderBy(l => l.Valor).LastOrDefault();
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
