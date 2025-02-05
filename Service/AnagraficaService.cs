using Data.EF;
using Model.Anagrafica;


namespace Service
{
    public class AnagraficaService
    {

        public WebAcademyContext _ctx;
        public AnagraficaService(WebAcademyContext webAcademyContext) {

            _ctx = webAcademyContext;
        }

        public List<GenereDTO> GetGeneri()
        {
            List<GenereDTO> listaGeneri = new List<GenereDTO>();
            return listaGeneri;
        }

        public void Create()
        {
            
        }
    }
}
