using Newtonsoft.Json;

namespace Application.Models.GiosStationModels
{
    public class IndexLevel
    {
        [JsonProperty("id")] public int Value { get; set; }
        [JsonProperty("indexLevelName")] public string IndexLevelName { get; set; }
    }
}