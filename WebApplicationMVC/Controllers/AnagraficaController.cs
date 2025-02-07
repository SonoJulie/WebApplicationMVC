using Microsoft.AspNetCore.Mvc;
using Model;
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

            model.Generi = _anagraficaService.GetGeneri();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUpdate(AnagraficaInputModel input)
        {
            BaseOutput output = await _anagraficaService.Create(input);

            if(!output.Success)
            {
                //Fallimento
                input.Output = output;
                input.Generi = _anagraficaService.GetGeneri();

                return View(input);
            }
            else
            {
                //Successo
                return RedirectToAction("Lista");
            }
        }



        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            ListaAnagraficheModel model = new ListaAnagraficheModel();

            model = await _anagraficaService.GetListAnagrafiche();
          
            return View(model);
        }


    }
}
