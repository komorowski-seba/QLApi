namespace Application.Models.Dto
{
    public class StationDto
    {
        public long Id { get; init; }
        public string StationName { get; init; }
        public string GegrLat { get; init; }
        public string GegrLon { get; init; }
        public string AddressStreet { get; init; }

        public StationDto(long id, string stationName, string gegrLat, string gegrLon, string addressStreet)
        {
            Id = id;
            StationName = stationName;
            GegrLat = gegrLat;
            GegrLon = gegrLon;
            AddressStreet = addressStreet;
        }
    }
}