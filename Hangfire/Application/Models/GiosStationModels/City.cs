using Newtonsoft.Json;

namespace Application.Models.GiosStationModels
{
    public class City
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("commune")]
        public Commune Commune { get; set; }
    }
}