using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace w1.Pages
{
    public class NuevoPaisModel : PageModel
    {
        [BindProperty]
        [Display(Name ="Pa�s")]
        [Required(ErrorMessage ="El Campo Pa�s no puede estar vac�o")]
        public string Pais { get; set; }
        [BindProperty]
        [Display(Name = "Capital")]
        [Required(ErrorMessage = "El Campo Capital no puede estar vac�o")]
        public string Capital { get; set; }
        [BindProperty]
        [Display(Name = "Continente")]
        [Required(ErrorMessage = "El Campo Continente no puede estar vac�o")]
        public int? ContinenteId { get; set; }

        public ActionResult OnGet()
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
