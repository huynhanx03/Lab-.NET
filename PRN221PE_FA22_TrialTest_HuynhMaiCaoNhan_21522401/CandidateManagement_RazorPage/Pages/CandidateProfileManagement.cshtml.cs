using Candidate_BusinessObjects;
using Candidate_Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CandidateManagement_RazorPage.Pages;

public class CandidateProfileManagement : PageModel
{
    private readonly ICandidateProfileRepo _candidateProfileRepo;
    private readonly IJobPostingRepo _jobPostingRepo;
    
    public CandidateProfileManagement(ICandidateProfileRepo candidateProfileRepo, IJobPostingRepo jobPostingRepo)
    {
        _candidateProfileRepo = candidateProfileRepo;
        _jobPostingRepo = jobPostingRepo;
    }
    [BindProperty]
    public CandidateProfile SelectedCandidateProfile { get; set; }
    
    public List<CandidateProfile> CandidateProfiles { get; set; }
    
    public List<JobPosting> JobPostings { get; set; }
    
    public List<SelectListItem> JobTitles { get; set; }
    
    public void OnGet()
    {
        var profiles = _candidateProfileRepo.GetCandidateProfilesList();
        CandidateProfiles = profiles;
        var jobPostings = _jobPostingRepo.GetJobPostingsList();
        JobTitles = jobPostings.Select(j => new SelectListItem
        {
            Value = j.PostingId,
            Text = j.JobPostingTitle
        }).ToList();
    }

    public IActionResult OnPostSelect(string candidateId)
    {
        SelectedCandidateProfile = _candidateProfileRepo.GetCandidateProfileById(candidateId);
        var jobPostings = _jobPostingRepo.GetJobPostingsList();
        JobTitles = jobPostings.Select(j => new SelectListItem
        {
            Value = j.PostingId,
            Text = j.JobPostingTitle
        }).ToList();
        CandidateProfiles = _candidateProfileRepo.GetCandidateProfilesList();
        return Page();
    }
    
    public void LoadDataInit()
    {
        SelectedCandidateProfile.CandidateId = "";
        SelectedCandidateProfile.Fullname = "";
        SelectedCandidateProfile.PostingId = "";
        SelectedCandidateProfile.ProfileShortDescription = "";
        SelectedCandidateProfile.ProfileUrl = "";
        SelectedCandidateProfile.Birthday = null;
        
        CandidateProfiles = _candidateProfileRepo.GetCandidateProfilesList();
        var posting = _jobPostingRepo.GetJobPostingsList();
        JobTitles = posting.Select(p => new SelectListItem
        {
            Value = p.PostingId,
            Text = p.JobPostingTitle
        }).ToList();
        RedirectToPage("FootballManagement");
    }

    public IActionResult OnPostAdd()
    {
        try
        {
            _candidateProfileRepo.AddCandidateProfile(SelectedCandidateProfile);
            CandidateProfiles = _candidateProfileRepo.GetCandidateProfilesList();
            TempData["SuccessMessage"] = "Add player successfully.";
            return Page();
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "Error adding player: " + e.Message);
            CandidateProfiles = _candidateProfileRepo.GetCandidateProfilesList();
            return RedirectToPage("/Error");
        }
    }

    public IActionResult OnPostDelete()
    {
        _candidateProfileRepo.RemoveCandidateProfile(SelectedCandidateProfile.CandidateId);
        CandidateProfiles = _candidateProfileRepo.GetCandidateProfilesList();
        TempData["SuccessMessage"] = "Delete player successfully.";
        return Page();
    }
    
    public IActionResult OnPostUpdate()
    {
        _candidateProfileRepo.UpdateCandidateProfile(SelectedCandidateProfile);
        CandidateProfiles = _candidateProfileRepo.GetCandidateProfilesList();
        TempData["SuccessMessage"] = "Update player successfully.";
        return RedirectToPage("CandidateProfileManagement");
    }
    
    public IActionResult OnPostClear()
    {
        LoadDataInit();
        return RedirectToPage("CandidateProfileManagement");
    }

    public IActionResult OnPostSearch(string searchTerm, string searchBy)
    {
        var profiles = _candidateProfileRepo.GetCandidateProfilesList();
        if (!string.IsNullOrEmpty(searchTerm))
        {
            if(searchBy == "name")
            {
                CandidateProfiles = _candidateProfileRepo.GetCandidateProfilesByName(searchTerm);
            }
            else if(searchBy == "description")
            {
                CandidateProfiles = _candidateProfileRepo.GetCandidateProfileByDescription(searchTerm);
            }
        }

        return Page();
    }
}