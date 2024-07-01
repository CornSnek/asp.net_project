using League.Data;
using League.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace League.Pages.Teams;

public class TeamsModel(ILogger<TeamsModel> logger, LeagueContext context) : PageModel
{
    private readonly ILogger<TeamsModel> _logger = logger;
    private readonly LeagueContext _context = context;
    public IQueryable<QTeams2>? QTeams { get; private set; }
    public IActionResult OnGet()
    {
        var teams=_context.Teams;
        var divisions=_context.Divisions;
        var conferences=_context.Conferences;
        var leagues=_context.Leagues;
        var q_teams1=teams.Join(divisions, teams=>teams.DivisionId, divisions=>divisions.DivisionId, (teams,d) => new QTeams1
        {
            TeamId = teams.TeamId,
            Name = teams.Name,
            Location = teams.Location,
            Win = teams.Win,
            Loss = teams.Loss,
            Tie = teams.Tie,
            WinPercentage = (double)teams.Win / (teams.Win + teams.Loss + teams.Tie),
            DivisionName = d.Name,
            ConferenceId = d.ConferenceId,
        });
        var q_teams2=q_teams1.Join(conferences,qt1=>qt1.ConferenceId,conferences=>conferences.ConferenceId,(qt1,c)=> new QTeams2{
            TeamId = qt1.TeamId,
            Name = qt1.Name,
            Location = qt1.Location,
            Win = qt1.Win,
            Loss = qt1.Loss,
            Tie = qt1.Tie,
            WinPercentage = qt1.WinPercentage,
            DivisionName = qt1.DivisionName,
            ConferenceName = c.Name,
        });
        QTeams = q_teams2.OrderByDescending(qteam2 => qteam2.WinPercentage).ThenBy(qteam2 => qteam2.Name);
        return Page();
    }
}