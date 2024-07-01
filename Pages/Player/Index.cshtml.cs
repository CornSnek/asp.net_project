using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace League.Pages.Player;

public class PlayerModel(ILogger<PlayerModel> logger,LeagueContext context) : PageModel
{
    private readonly ILogger<PlayerModel> _logger = logger;
    private readonly LeagueContext _context = context;
    public Models.Player? ThisPlayer {get; private set;}

    public async Task<IActionResult> OnGetAsync(string Id)
    {
        ThisPlayer = await _context.Players.FindAsync(Id);
        if(ThisPlayer==null) return NotFound();
        ThisPlayer.Team = await _context.Teams.FindAsync(ThisPlayer.TeamId);
        if(ThisPlayer.Team==null) return NotFound();
        return Page();
    }
}

