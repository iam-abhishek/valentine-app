using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myvapp.Data;
using myvapp.Models;

namespace myvapp.Pages
{
    public class YesModel : PageModel
    {
        private readonly LoveDbContext _context;

        public YesModel(LoveDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Authorized") != "true")
                return Redirect("https://google.com");

            var response = new ValentineResponse
            {
                Response = "Yes",
                RespondedAt = DateTime.Now,
                Device = Request.Headers["User-Agent"].ToString()
            };

            _context.ValentineResponses.Add(response);
            _context.SaveChanges();

            return Page();
        }
    }


}
