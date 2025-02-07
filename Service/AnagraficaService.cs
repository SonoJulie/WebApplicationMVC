using Data.EF;
using Microsoft.EntityFrameworkCore;
using Model;
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
            var generiAttivi = _ctx.SysGenere.Where(x => x.FAttivo);

            listaGeneri = generiAttivi.Select(x =>  new GenereDTO()
            {
                Id = x.Id,
                Genere = x.Genere,

            }).ToList();


            return listaGeneri;
        }

        public async Task<BaseOutput> Create(AnagraficaInputModel input)
        {
            BaseOutput output = new BaseOutput();

            try
            {
                Anagrafica anagrafica = new Anagrafica()
                {
                    Nome = input.Nome,
                    Cognome = input.Cognome,
                    Eta = input.Eta,
                    PesoAttuale = input.PesoAttuale,
                    Altezza = input.Altezza,
                    IdGenere = input.IdGenere,
                    ConsensoPrivacy = input.ConsensoPrivacy,
                    Note = input.Note
                };

                _ctx.Anagrafica.Add(anagrafica);

                await _ctx.SaveChangesAsync();

                output.Success = true;

            }
            catch (Exception ex)
            {
                output.Success = false;
                output.ErrorMessage = "Errore nel salvtaggio dell'anagrafica";
            }


            return output;
        }


        public async Task<ListaAnagraficheModel> GetListAnagrafiche()
        {
            ListaAnagraficheModel model = new ListaAnagraficheModel()
            {
                Anagrafiche = new List<AnagraficaDTO>(),
                Output = new BaseOutput()
            };

            try
            {
                var anagraficheEF = _ctx.Anagrafica.Include(x => x.IdGenereNavigation).OrderByDescending(x => x.Id);
                model.Anagrafiche = await anagraficheEF.Select(x => new AnagraficaDTO()
                {
                    IdAnagrafica = x.Id,
                    Nome = x.Nome,
                    Cognome = x.Cognome,
                    Eta = x.Eta,
                    Genere = x.IdGenereNavigation.Genere

                }).ToListAsync();

                model.Output.Success = true;
            }
            catch (Exception ex)
            {
                model.Output.Success = false;
                model.Output.ErrorMessage = "Errore nel recupero delle anagrafiche";
            }

            return model;

        }

    }
}
