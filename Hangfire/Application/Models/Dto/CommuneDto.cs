namespace Application.Models.Dto
{
    public class CommuneDto
    {
        public string DistrictName { get; init; }
        public string CommuneName { get; init; }
        public IList<CityDto> Citys { get; init; }

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