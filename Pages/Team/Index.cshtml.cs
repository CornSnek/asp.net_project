using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace League.Pages.Team;

public class TeamModel(ILogger<TeamModel> logger, LeagueContext context) : PageModel
{
  private readonly ILogger<TeamModel> _logger = logger;
  private readonly LeagueContext _context = context;
  public Models.Team? ThisTeam { get; private set; }
  [BindProperty]
  public string FavoriteId { get; set; } = "";
  public async Task<IActionResult> OnGetAsync(string Id)
  {
    ThisTeam = await _context.Teams.FindAsync(Id);
    if (ThisTeam == null) return NotFound();
    ThisTeam.Players = [.. from player in _context.Players
                            where player.TeamId==ThisTeam.TeamId
                            select player];
    if (ThisTeam.Players == null) return NotFound();
    if (!string.IsNullOrEmpty(FavoriteId)){
      HttpContext.Session.SetString("FavoriteTeam", ThisTeam.TeamId);
    }
    return Page();
  }
  public async Task<IActionResult> OnPostAsync(string Id)
  {
    return await OnGetAsync(Id);
  }
}

