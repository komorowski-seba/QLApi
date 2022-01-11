using Domain.Common;

namespace Domain.Entities.ProvinceContext
{
    public class Province : IAggregateRoot
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }

        private readonly List<Commune> _communes;
        public IReadOnlyCollection<Commune> Communes => _communes;

        
        public Province(string name)
        {
            if (string.IsNullOrEmpty(name)) 
                throw new ArgumentNullException(nameof(name));
            
            Id = Guid.NewGuid();
            Name = name;
            _communes = new List<Commune>();
        }

        public Commune AddCommune(string provinceName, string districtName, string communeName)
        {
            var communeId = Commune.GetCommuneId(provinceName, districtName, communeName);
            var commune = _communes.FirstOrDefault(n => n.Id == communeId);
            if (commune != null) 
                return commune;
            
            commune = new Commune(communeId, districtName, communeName);
            _communes.Add(commune);
            return commune;
        }
    }
}