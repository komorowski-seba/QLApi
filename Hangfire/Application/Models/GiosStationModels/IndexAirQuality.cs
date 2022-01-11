using Newtonsoft.Json;
// using System.Text.Json.Serialization;

namespace Application.Models.GiosStationModels
{
    public class IndexAirQuality
    {
        [JsonProperty("id", NullValueHandling=NullValueHandling.Ignore)] public long Id { get; set; }
        [JsonProperty("stCalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset CalculateDate { get; set; }
        [JsonProperty("stIndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel StationIndexLevel { get; set; }
        [JsonProperty("stSourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset SourceDataDate { get; set; }
        [JsonProperty("stIndexStatus", NullValueHandling=NullValueHandling.Ignore)] public bool IndexStatus { get; set; }
        [JsonProperty("stIndexCrParam", NullValueHandling=NullValueHandling.Ignore)] public string IndexCrParam { get; set; }
        
        [JsonIgnore] public string CityName { get; set; }
        [JsonIgnore] public string ProvinceName { get; set; }

        // SO2
        [JsonProperty("so2CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset So2CalcDate { get; set; }
        [JsonProperty("so2IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel So2IndexLevel { get; set; }
        [JsonProperty("so2SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset So2SourceDataDate { get; set; }
        
        // NO2
        [JsonProperty("no2CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset No2CalcDate { get; set; }
        [JsonProperty("no2IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel No2IndexLevel { get; set; }
        [JsonProperty("no2SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset No2SourceDataDate { get; set; }
        
        // PM10
        [JsonProperty("pm10CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset Pm10CalcDate { get; set; }
        [JsonProperty("pm10IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel Pm10IndexLevel { get; set; }
        [JsonProperty("pm10SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset Pm10SourceDataDate { get; set; }
        
        // PM25
        [JsonProperty("pm25CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset Pm25CalcDate { get; set; }
        [JsonProperty("pm25IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel Pm25IndexLevel { get; set; }
        [JsonProperty("pm25SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTime Pm25SourceDataDate { get; set; }
        
        // O3
        [JsonProperty("o3CalcDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset O3CalcDate { get; set; }
        [JsonProperty("o3IndexLevel", NullValueHandling=NullValueHandling.Ignore)] public IndexLevel O3IndexLevel { get; set; }
        [JsonProperty("o3SourceDataDate", NullValueHandling=NullValueHandling.Ignore)] public DateTimeOffset O3SourceDataDate { get; set; }
    }
}