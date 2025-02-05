using System;
using System.Collections.Generic;

namespace Data.EF;

public partial class SysGenere
{
    public int Id { get; set; }

    public string Genere { get; set; } = null!;

    public bool FAttivo { get; set; }

    public virtual ICollection<Anagrafica> Anagrafica { get; set; } = new List<Anagrafica>();
}
