using League.Models.Queries;

namespace League.Models.Views
{
  public class PlayersSection{
    public string? Name;
    public string Depth;
    public string? Position;
    public string TeamName;
    public PlayersSection(){
      Name="Name";
      Depth="Depth";
      Position="Position";
      TeamName="Team";
    }
    public PlayersSection(Player player,string team_name){
      Name=player.Name;
      if(player.Depth!=null){
        Depth=((int)player.Depth).ToString();
      }else{
        Depth="N/A";
      }
      Position=player.Position;
      TeamName=team_name;
    }
    public PlayersSection(QPlayers qplayer){
      Name=qplayer.Name;
      if(qplayer.Depth!=null){
        Depth=((int)qplayer.Depth).ToString();
      }else{
        Depth="N/A";
      }
      Position=qplayer.Position;
      TeamName=qplayer.TeamName;
    }
  }
}