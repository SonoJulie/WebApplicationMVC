using System;
using System.Collections.Generic;

namespace Data.EF;

public partial class Anagrafica
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public int Eta { get; set; }

    public bool ConsensoPrivacy { get; set; }

    public decimal PesoAttuale { get; set; }

    public decimal Altezza { get; set; }

    public int IdGenere { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<DiarioAlimentare> DiarioAlimentare { get; set; } = new List<DiarioAlimentare>();

    public virtual SysGenere IdGenereNavigation { get; set; } = null!;
}
