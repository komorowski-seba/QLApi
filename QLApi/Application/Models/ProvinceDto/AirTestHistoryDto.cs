namespace Application.Models.ProvinceDto;

public class AirTestHistoryDto
{
    public DateTime UpdateDate { get; set; }
    public long StationId { get; set; }

    public IList<AirTestDto> AirTests { get; set; } = new List<AirTestDto>();
}