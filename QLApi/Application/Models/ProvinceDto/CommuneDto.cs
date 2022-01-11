namespace Application.Models.ProvinceDto
{
    public class CommuneDto
    {
        public long Id { get; set; }
        public string DistrictName { get; set; } = "";
        public string CommuneName { get; set; } = "";
        public IList<CityDto> Citys { get; set; } = new List<CityDto>();

        public CommuneDto() { }
        
        public CommuneDto(string districtName, string communeName)
        {
            DistrictName = districtName;
            CommuneName = communeName;
            Citys = new List<CityDto>();
        }

        public CityDto AddCity(long id, string name)
        {
            var find = Citys.FirstOrDefault(n => n.Id == id);
            if (find != null)
                return find;

            var result = new CityDto(id, name);
            Citys.Add(result);
            return result;
        }
    }
}