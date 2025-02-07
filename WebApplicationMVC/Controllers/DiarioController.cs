using Microsoft.AspNetCore.Mvc;
using Model.Diario;
using Service;

namespace WebApplicationMVC.Controllers
{
    public class DiarioController :  Controller
    {
        private DiarioService diarioService;

        public DiarioController(DiarioService diarioS) 
        { 
            diarioService = diarioS;
        }

        [HttpGet]
        public IActionResult Diario(int idAnagrafica) 
        { 
            DiarioAlimentareModel model = new DiarioAlimentareModel();

            model = diarioService.GetAlimentareModel(idAnagrafica);

            return View("DiarioAlimentare", model);
        }


        public IActionResult Check(int idAnagrafica)
        {
            return View();

        }


    }
}
