namespace Application.Models.ProvinceDto
{
    public class StationDto
    {
        public long Id { get; set; }
        public string StationName { get; set; } = "";
        public string GegrLat { get; set; } = "";
        public string GegrLon { get; set; } = "";
        public string AddressStreet { get; set; } = "";

        public StationDto() { }
        
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