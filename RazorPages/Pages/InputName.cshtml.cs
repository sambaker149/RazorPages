using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class InputNameModel : PageModel
    {
        [BindProperty]
        public string FullName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        private readonly ILogger<InputNameModel> _logger;

        public InputNameModel(ILogger<InputNameModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["Message"] = "Please Fill Out all Fields";
        }

        public void OnPost()
        {
            if(String.IsNullOrWhiteSpace(FullName))
            {
                ViewData["Message"] = "Please Enter your Full Name";
            }
            else
            {
                ViewData["Message"] = "Thank You " + FullName + ", Your Registration has been Successful";
            }
        }
    }
}