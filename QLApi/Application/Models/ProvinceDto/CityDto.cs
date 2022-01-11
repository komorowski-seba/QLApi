namespace Application.Models.ProvinceDto
{
    public class CityDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public IList<StationDto> Stations { get; set; } = new List<StationDto>();

        public CityDto() { }

        public CityDto(long id, string name)
        {
            Id = id;
            Name = name;
            Stations = new List<StationDto>();
        }

        public void AddStation(long id, string stationName, string gegrLat, string gegrLon, string addressStreet)
        {
            if (Stations.Any(n => n.Id == id))
                return;

            var result = new StationDto(id, stationName, gegrLat, gegrLon, addressStreet);
            Stations.Add(result);
        }
    }
}