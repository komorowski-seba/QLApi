using Newtonsoft.Json;

namespace Application.Models.GiosStationModels
{
    public class Station
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("stationName")]
        public string StationName { get; set; }

        [JsonProperty("gegrLat")]
        public string GegrLat { get; set; }

        [JsonProperty("gegrLon")]
        public string GegrLon { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("addressStreet")]
        public string AddressStreet { get; set; }
    }
}