namespace League.Models.Views
{
  public class KeyValueSection
  {
    public string SectionName;
    public string Value;
    public KeyValueSection(string section_name, string? value){
      SectionName = section_name;
      Value = value ?? "N/A";
    }
    public KeyValueSection(string section_name, int? value){
      SectionName = section_name;
      if(value!=null){
        Value = ((int)value).ToString();
      }else{
        Value = "N/A";
      }
    }
    public KeyValueSection(string section_name, double? value, string? format=null){
      SectionName = section_name;
      if(value!=null){
        Value = ((double)value).ToString(format);
      }else{
        Value = "N/A";
      }
    }
  }
}