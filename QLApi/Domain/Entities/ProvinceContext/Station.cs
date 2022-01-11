namespace Domain.Entities.ProvinceContext
{
    public class Station
    {
        public long Id { get; private set; }
        public string StationName { get; private set; }
        public string GegrLat { get; private set; }
        public string GegrLon { get; private set; }
        public string AddressStreet { get; private set; }
        public long CityId { get; init; }
        
        public City City { get; private set; }
        
        public Station(long id, string stationName, string gegrLat, string gegrLon, string addressStreet)
        {
            if (string.IsNullOrEmpty(stationName))
                throw new ArgumentNullException(nameof(stationName));
            if (string.IsNullOrEmpty(gegrLat))
                throw new ArgumentNullException(nameof(gegrLat));
            if (string.IsNullOrEmpty(gegrLon))
                throw new ArgumentNullException(nameof(gegrLon));
            
            Id = id;
            StationName = stationName;
            GegrLat = gegrLat;
            GegrLon = gegrLon;
            AddressStreet = addressStreet ?? "";
        }
    }
}