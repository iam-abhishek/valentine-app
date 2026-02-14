using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myvapp.Data;
using QuestPDF.Fluent;

public class CertificateModel : PageModel
{
    private readonly LoveDbContext _context;

    public string Timestamp { get; set; }

    public CertificateModel(LoveDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet(string key)
    {
        if (HttpContext.Session.GetString("Authorized") != "true")
            return Redirect("https://google.com");

        var lastResponse = _context.ValentineResponses
            .OrderByDescending(x => x.RespondedAt)
            .FirstOrDefault();

        if (lastResponse != null)
            Timestamp = lastResponse.RespondedAt.ToString("dd MMM yyyy - hh:mm tt");
        else
            Timestamp = "Forever ❤️";

        return Page();
    }

    public IActionResult OnGetDownload(string key)
    {
        if (key != "onlyForShreya")
            return Redirect("https://google.com");

        var lastResponse = _context.ValentineResponses
            .OrderByDescending(x => x.RespondedAt)
            .FirstOrDefault();

        var timestamp = lastResponse != null
            ? lastResponse.RespondedAt.ToString("dd MMM yyyy - hh:mm tt")
            : "Forever";

        var document = new CertificateDocument(timestamp, "Shreya");

        var pdf = document.GeneratePdf();

        return File(pdf, "application/pdf", "RoyalLoveCertificate.pdf");
    }




}

