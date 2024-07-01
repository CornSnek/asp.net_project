namespace League.Models.Views;
public class TeamsSection{
  public string Name;
  public string Location;
  public string Win;
  public string Loss;
  public string Tie;
  public string WinPercentage;
  public string DivisionName;
  public string? ConferenceName;
  public TeamsSection(){
    Name="Name";
    Location="Location";
    Win="Win";
    Loss="Loss";
    Tie="Tie";
    WinPercentage="Win Percentage";
    DivisionName="Division Name";
    ConferenceName="Conference Name";
  }
  public TeamsSection(Queries.QTeams2 qteam){
    Name=qteam.Name;
    Location=qteam.Location;
    Win=qteam.Win.ToString();
    Loss=qteam.Loss.ToString();
    Tie=qteam.Tie.ToString();
    WinPercentage=qteam.WinPercentage.ToString("P2");
    DivisionName=qteam.DivisionName;
    ConferenceName=qteam.ConferenceName;
  }
}