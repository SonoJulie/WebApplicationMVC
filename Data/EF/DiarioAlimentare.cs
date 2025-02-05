using System;
using System.Collections.Generic;

namespace Data.EF;

public partial class DiarioAlimentare
{
    public int Id { get; set; }

    public int IdAnagrafica { get; set; }

    public decimal Peso { get; set; }

    public decimal Altezza { get; set; }

    public DateTime DataRegistrazione { get; set; }

    public bool FAttivo { get; set; }

    public virtual Anagrafica IdAnagraficaNavigation { get; set; } = null!;
}
