using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace League.Pages;

public class IndexModel(ILogger<IndexModel> logger, LeagueContext context) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly LeagueContext _context = context;
    public Models.League[]? Leagues {get; private set;}
    public async Task<IActionResult> OnGetAsync()
    {
        Leagues = await _context.Leagues.ToArrayAsync();
        return Page();
    }
}
