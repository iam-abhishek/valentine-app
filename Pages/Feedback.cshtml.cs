using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myvapp.Data;
using myvapp.Models;

namespace myvapp.Pages
{
    public class FeedbackModel : PageModel
    {
        private readonly LoveDbContext _context;

        public FeedbackModel(LoveDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Authorized") != "true")
                return Redirect("https://google.com");

            return Page();
        }


        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public string? Message { get; set; }

        public IActionResult OnPost()
        {
            var feedback = new LoveFeedback
            {
                Rating = Rating,
                Message = Message,
                SubmittedAt = DateTime.Now
            };

            _context.LoveFeedbacks.Add(feedback);
            _context.SaveChanges();

            return RedirectToPage("Certificate");

        }
    }

}
