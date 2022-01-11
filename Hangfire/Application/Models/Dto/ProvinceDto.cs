namespace Application.Models.Dto
{
    public class ProvinceDto
    {
        public string Name { get; init; }
        public IList<CommuneDto> Communes { get; init; }

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