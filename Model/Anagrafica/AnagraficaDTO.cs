using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Anagrafica
{
    public class AnagraficaDTO
    {
        public int IdAnagrafica { get; set; }
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public int Eta { get; set; }

        public string Genere { get; set; }

    }
}
