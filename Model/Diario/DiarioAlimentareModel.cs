using Model.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Diario
{
    public class DiarioAlimentareModel
    {
        public BaseOutput BaseOutput { get; set; }

        public List<CheckDTO> Diario { get; set; }

        public AnagraficaDTO Anagrafica { get; set; }

        public double AltezzaIniziale { get; set; }

        public double PesoIniziale { get; set; }
    }
}
