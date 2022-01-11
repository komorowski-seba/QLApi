using Newtonsoft.Json;

namespace Application.Models.GiosStationModels
{
    public class Commune
    {
        [JsonProperty("communeName")]
        public string CommuneName { get; set; }

        [JsonProperty("districtName")]
        public string DistrictName { get; set; }

        [JsonProperty("provinceName")]
        public string ProvinceName { get; set; }
    }
}