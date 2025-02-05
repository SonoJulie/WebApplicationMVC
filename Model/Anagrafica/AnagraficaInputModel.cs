namespace Model.Anagrafica
{
    public class AnagraficaInputModel
    {
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public int Eta { get; set; }

        public bool ConsensoPrivacy { get; set; }

        public decimal PesoAttuale { get; set; }

        public decimal Altezza { get; set; }

        public int IdGenere { get; set; }

        public string? Note { get; set; }

        public List<GenereDTO> Generi { get; set; } = new List<GenereDTO>();

    }



}
