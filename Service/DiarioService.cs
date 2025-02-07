using Data.EF;
using Model;
using Model.Diario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DiarioService
    {

        public WebAcademyContext _ctx;
        public DiarioService(WebAcademyContext webAcademyContext)
        {
            _ctx = webAcademyContext;
        }

        public DiarioAlimentareModel GetAlimentareModel(int IdAnagrafica)
        {
            DiarioAlimentareModel model = new DiarioAlimentareModel()
            {
                BaseOutput = new Model.BaseOutput(),
            };
         
            try
            {
                if(_ctx.Anagrafica.Any(x => x.Id == IdAnagrafica))
                {
                    var anagraficaEF = _ctx.Anagrafica.FirstOrDefault(x => x.Id == IdAnagrafica);
                    model.Anagrafica = new Model.Anagrafica.AnagraficaDTO()
                    {
                        Cognome = anagraficaEF.Cognome,
                        Nome = anagraficaEF.Nome,
                        Eta = anagraficaEF.Eta,
                    };

                    model.AltezzaIniziale = (double)anagraficaEF.Altezza;
                    model.PesoIniziale = (double)anagraficaEF.PesoAttuale;

                    var diarioEF = _ctx.DiarioAlimentare.Where(x => x.IdAnagrafica == IdAnagrafica && x.FAttivo);

                    model.Diario = diarioEF.Select(x => new CheckDTO()
                    {
                        Altezza = x.Altezza,
                        Peso = x.Peso,
                        DataRegistrazione = x.DataRegistrazione,

                    }).ToList();

                }
                else
                {
                    model.BaseOutput.Success = false;
                    model.BaseOutput.ErrorMessage = "Nessuna anagrafica trovata";
                }
              
            }
            catch (Exception ex)
            {
                model.BaseOutput.Success = false;
                model.BaseOutput.ErrorMessage = "Errore nel caricamento della interfaccia di dettaglio";
            }

            return model;
        }

        public async Task<BaseOutput> SaveCheck(CheckDTO input)
        {
            BaseOutput output = new BaseOutput();
            try
            {

            }
            catch (Exception ex)
            {

                output.Success = false;
                output.ErrorMessage = "Errore nel salvataggio del peso";
            }
            return output;
        }
    }
}
