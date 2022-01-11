using Newtonsoft.Json;

namespace Application.Models.Redis;

public class Station
{
    [JsonProperty("id")] public long Id { get; set; }
    [JsonProperty("stationName")] public string StationName { get; set; }
    [JsonProperty("gegrLat")] public string GegrLat { get; set; }
    [JsonProperty("gegrLon")] public string GegrLon { get; set; }
    [JsonProperty("city")] public  string City { get; set; }
    [JsonProperty("province")] public string Province { get; set; }
}