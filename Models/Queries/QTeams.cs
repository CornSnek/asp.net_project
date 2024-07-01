namespace League.Models.Queries
{
  //Join Team + Division.
  public class QTeams1
  {
    public required string TeamId;
    public required string Name;
    public required string Location;
    public required int Win;
    public required int Loss;
    public required int Tie;
    public required double WinPercentage;
    public required string DivisionName;
    public required string? ConferenceId;
  }
  //Join Team + Division + Conference
  public class QTeams2{
    public required string TeamId;
    public required string Name;
    public required string Location;
    public required int Win;
    public required int Loss;
    public required int Tie;
    public required double WinPercentage;
    public required string DivisionName;
    public required string? ConferenceName;
  }
}