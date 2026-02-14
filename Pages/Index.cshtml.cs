using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myvapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet(string key)
    {
        if (key == "ourSecretKey123")
        {
            HttpContext.Session.SetString("Authorized", "true");
            return Page();
        }

        return Redirect("https://google.com");
    }

}
