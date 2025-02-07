using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Anagrafica
{
    public class ListaAnagraficheModel
    {
        public List<AnagraficaDTO> Anagrafiche { get; set; }

        public BaseOutput Output { get; set; }
    }
}
