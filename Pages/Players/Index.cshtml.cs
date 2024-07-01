using League.Data;
using League.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace League.Pages.Players;

public class PlayersModel(ILogger<PlayersModel> logger, LeagueContext context) : PageModel
{
    private readonly ILogger<PlayersModel> _logger = logger;
    private readonly LeagueContext _context = context;
    public IQueryable<QPlayers>? QPlayers { get; private set; }
    [BindProperty(SupportsGet = true)]
    public string SortBy { get; set; } = "Name";
    [BindProperty(SupportsGet = true)]
    public string FilterBy { get; set; } = "Name";
    [BindProperty(SupportsGet = true)]
    public string Filter { get; set; } = "";
    public IQueryable<string>? FilterList;

    public IActionResult OnGet()
    {
        QPlayers = from player in _context.Players
                   join team in _context.Teams on player.TeamId equals team.TeamId
                   select new QPlayers
                   {
                       PlayerId = player.PlayerId,
                       Name = player.Name,
                       Depth = player.Depth,
                       Position = player.Position,
                       TeamName = team.Name,
                       TeamId = team.TeamId,
                   };
        switch(FilterBy){
            case "Depth":
                FilterList = QPlayers.Select(p=>p.Depth!=null?((int)p.Depth).ToString():"N/A").Distinct();
                break;
            case "Position":
                FilterList = QPlayers.Select(p=>p.Position).Distinct();
                break;
            case "Team":
                FilterList = QPlayers.Select(p=>p.TeamName).Distinct();
                break;
        }
        if (!string.IsNullOrEmpty(Filter))
        {
            switch (FilterBy)
            {
                case "Name":
                    QPlayers = QPlayers.Where(p => p.Name.ToLower().Contains(Filter.ToLower()));
                    break;
                case "Depth":
                    QPlayers = QPlayers.Where(p => p.Depth!=null?((int)p.Depth).ToString().Contains(Filter):"N/A".Contains(Filter));
                    break;
                case "Position":
                    QPlayers = QPlayers.Where(p => p.Position.ToLower().Contains(Filter.ToLower()));
                    break;
                case "Team":
                    QPlayers = QPlayers.Where(p => p.TeamName.ToLower().Contains(Filter.ToLower()));
                    break;
            }
        }
        switch (SortBy)
        {
            case "Name":
                QPlayers = QPlayers.OrderBy(p => p.Name);
                break;
            case "Depth":
                QPlayers = QPlayers.OrderBy(p => p.Depth);
                break;
            case "Position":
                QPlayers = QPlayers.OrderBy(p => p.Position);
                break;
            case "Team":
                QPlayers = QPlayers.OrderBy(p => p.TeamName);
                break;
        }
        return Page();
    }
}