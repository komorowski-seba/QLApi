namespace Application.Models.ProvinceDto;

public class AirTestDto
{
    public long StationId { get; set; }
    public DateTime CalcDate { get; set; }
    public DateTime DownloadDate { get; set; }
    public string CityName { get; set; }
    public string ProvinceName { get; set; }
    public int So2IndexLevel { get; set; }
    public string So2IndexName { get; set; }
    public int No2IndexLevel { get; set; }
    public string No2IndexName { get; set; }
    public int Pm10IndexLevel { get; set; }
    public string Pm10IndexName { get; set; }
    public int Pm25IndexLevel { get; set; }
    public string Pm25IndexName { get; set; }
    public int O3IndexLevel { get; set; }
    public string O3IndexName { get; set; }
}