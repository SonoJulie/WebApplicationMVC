using Microsoft.AspNetCore.Mvc;
using Model.Anagrafica;
using Service;


namespace WebApplicationMVC.Controllers
{
    public class AnagraficaController : Controller
    {

        private AnagraficaService _anagraficaService;

        public AnagraficaController(AnagraficaService anagraficaService )
        {
            _anagraficaService = anagraficaService;
        }


        [HttpGet]
        public IActionResult CreateUpdate()
        {
            AnagraficaInputModel model = new AnagraficaInputModel();
        
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateUpdate(AnagraficaInputModel input)
        {

            return View();
        }
    }
}
