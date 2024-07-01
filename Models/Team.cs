using System.Collections.Generic;

namespace League.Models
{
  public class Team
  {
    public required string DivisionId { get; set; }
    public required string TeamId { get; set; }
    public required string Location { get; set; }
    public required string Name { get; set; }
    public int Win { get; set; }
    public int Loss { get; set; }
    public int Tie { get; set; }
    public int PointsFor { get; set; }
    public int PointsAgainst { get; set; }
    public required string Stadium { get; set; }
    public int Capacity { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Zip { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Division? Division { get; set; }
    
    public ICollection<Player>? Players { get; set; }
  }
}
