using Candidate_Repository;
using Candidate_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GermanyEuro2024_RazorPage.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHRAccountRepo _hraccountRepo;
    public IndexModel(ILogger<IndexModel> logger,IHRAccountRepo hraccountRepo)
    {
        _logger = logger;

        _hraccountRepo = hraccountRepo;

    }
    
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }
    
    public string ErrorMessage { get; set; }

    public IActionResult OnPost()
    {
        Hraccount hraccount = _hraccountRepo.GetHraccountByEmail(Email);

        if (hraccount != null && hraccount.Password == Password)
        {
            return RedirectToPage("/CandidateProfileManagement");
        }
        else
        {
            ErrorMessage = "Invalid email or password";
            return Page();
        }
    }
}