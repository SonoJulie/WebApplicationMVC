namespace WebApplicationMVC.Models
{
    public class ContattoModel
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }
       
        public int Sesso {  get; set; }

        public List<Sesso> Generi { get; set; }

    }

    public class Sesso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
