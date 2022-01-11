namespace Domain.Entities.ProvinceContext
{
    public class Commune
    {
        public long Id { get; init; }
        public Guid ProvinceId { get; init; }
        public string DistrictName { get; private set; }
        public string CommuneName { get; private set; }

        public Province Province { get; private set; }
        
        private readonly List<City> _cities;
        public IReadOnlyCollection<City> Cities => _cities;

        protected Commune()
        {
        }

        public Commune(long id, string districtName, string communeName)
        {
            if (string.IsNullOrEmpty(districtName))
                throw new ArgumentNullException(nameof(districtName));
            if (string.IsNullOrEmpty(communeName))
                throw new ArgumentNullException(nameof(communeName));

            Id = id;
            DistrictName = districtName;
            CommuneName = communeName;
            _cities = new List<City>();
        }

        public City AddCity(long id, string name)
        {
            var city = _cities.FirstOrDefault(n => n.Id == id);
            if (city != null) 
                return city;
            
            city = new City(id, name);
            _cities.Add(city);
            return city;
        }

        public static long GetCommuneId(string provinceName, string districtName, string communeName) 
            => $"{provinceName}-{communeName}-{districtName}".GetHashCode();
    }
}