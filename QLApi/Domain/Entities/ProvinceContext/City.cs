namespace Domain.Entities.ProvinceContext
{
    public class City
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public long CommuneId { get; init; }
        
        public Commune Commune { get; private set; }
        
        private readonly List<Station> _stations;
        public IReadOnlyCollection<Station> Stations => _stations;

        
        public City(long id, string name)
        {
            if (id <= 0)
                throw new AggregateException($"{nameof(id)} can't be less than zero");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            
            Id = id;
            Name = name;
            _stations = new List<Station>();
        }

        public void AddStation(long id, string stationName, string gegrLat, string gegrLon, string addressStreet)
        {
            var find = _stations.FirstOrDefault(n => n.Id == id);
            if (find != null)
                return;
            
            _stations.Add(new Station(id, stationName, gegrLat, gegrLon, addressStreet));
        }

    }
}