using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using w1.Pages.Repositorios;

namespace w1.Pages
{
    public class IndexModel : PageModel
    {
        [Display(Name ="Usuario")]
        [BindProperty]
        [Required(ErrorMessage ="El Campo Usuario no puede estar vacío")]
        public string NombreUsuario { get; set; }
        private readonly ILogger<IndexModel> _logger;

        [Display(Name ="Contraseña")]
        [BindProperty]
        [Required(ErrorMessage ="El Campo Contraseña no puede estar vacío")]
        public string Password { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {        if (ModelState.IsValid)
            { 
            var usuario = this.NombreUsuario;
            var password = this.Password;

                var respo = new LoginRepositorio();
                bool resultadoValidacion = respo.ExisteUsuario(usuario, password);

                if (resultadoValidacion == true)
                {
                    Guid idSession = Guid.NewGuid();
                    HttpContext.Session.SetString("idSession", idSession.ToString());
                    return RedirectToPage("./Home");
                }
                ModelState.AddModelError(string.Empty, "Usuario o Contraseña inválidos");
                return Page();
            }

            return Page();
        }
    }
}
