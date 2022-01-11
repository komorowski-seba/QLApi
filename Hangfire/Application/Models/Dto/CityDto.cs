namespace Application.Models.Dto
{
    public class CityDto
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public IList<StationDto> Stations { get; init; }

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