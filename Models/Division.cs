namespace League.Models
{
  public class Division
  {
    public required string ConferenceId { get; set; }
    public required string DivisionId { get; set; }
    public required string Name { get; set; }

    public Conference? Conference { get; set; }
  }
}
