using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class RegisterController : Controller
    {
        private List<Sesso> generi  = new List<Sesso>() {
                    new Sesso() { Id = 1, Nome = "F" },
                    new Sesso() { Id = 2, Nome = "M" },
                    new Sesso() { Id = 3, Nome = "N" },
                };

        [HttpGet]
        public IActionResult Registrazione()
        {
            ContattoModel model = new ContattoModel()
            {
                Generi = generi
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Registrazione(ContattoModel modelInput)
        {
            ListModel listModel = new ListModel()
            {
                Contatti = new List<ContattoModel>()
                {
                    modelInput
                },
                Generi = generi
            };

            
            return View("Lista", listModel);
            
        }






    }
}
