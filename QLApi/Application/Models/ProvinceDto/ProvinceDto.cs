namespace Application.Models.ProvinceDto
{
    public class ProvinceDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public IList<CommuneDto> Communes { get; set; } = new List<CommuneDto>();

        public ProvinceDto() { }

        public ProvinceDto(string name)
        {
            Name = name;
            Communes = new List<CommuneDto>();
        }

        public CommuneDto AddCommune(string districtName, string communeName)
        {
            var find = Communes.FirstOrDefault(n =>
                string.Equals(n.CommuneName, communeName, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(n.DistrictName, districtName, StringComparison.CurrentCultureIgnoreCase));
            if (find != null)
                return find;
            
            var result = new CommuneDto(districtName, communeName);
            Communes.Add(result);
            return result;
        }
    }
}