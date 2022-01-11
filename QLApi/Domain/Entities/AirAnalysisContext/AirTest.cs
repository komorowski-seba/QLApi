namespace Domain.Entities.AirAnalysisContext
{
    public class AirTest
    {
        public Guid Id { get; init; }
        public long StationId { get; private set; }
        public DateTime CalcDate { get; private set; }
        public DateTime DownloadDate { get; private set; }
        public int So2IndexLevel { get; private set; }
        public string So2IndexName { get; private set; }
        public int No2IndexLevel { get; private set; }
        public string No2IndexName { get; private set; }
        public int Pm10IndexLevel { get; private  set; }
        public string Pm10IndexName { get; private  set; }
        public int Pm25IndexLevel { get; private  set; }
        public string Pm25IndexName { get; private  set; }
        public int O3IndexLevel { get; private  set; }
        public string O3IndexName { get; private  set; }
        
        public Guid AirHistoryId { get; private set; }
        public AirTestHistory AirHistory { get; private set; }
        
        public AirTest() { }
        
        public AirTest(long stationId,
            DateTime calcDate,
            DateTime downloadDate, 
            int so2IndexLevel, 
            string so2IndexName, 
            int no2IndexLevel,
            string no2IndexName,
            int pm10IndexLevel,
            string pm10IndexName,
            int pm25IndexLevel,
            string pm25IndexName,
            int o3IndexLevel,
            string o3IndexName,
            AirTestHistory airHistory)
        {
            if (calcDate == null)
                throw new ArgumentNullException(nameof(calcDate));
            if (downloadDate == null)
                throw new ArgumentNullException(nameof(downloadDate));
            if (so2IndexLevel < 0)
                throw new AggregateException($"{nameof(so2IndexLevel)} can't be less than zero");
            if (string.IsNullOrEmpty(so2IndexName))
                throw new ArgumentNullException(nameof(so2IndexName));
            if (no2IndexLevel < 0)
                throw new AggregateException($"{nameof(no2IndexLevel)} can't be less than zero");
            if (string.IsNullOrEmpty(no2IndexName))
                throw new ArgumentNullException(nameof(no2IndexName));
            if (pm10IndexLevel < 0)
                throw new AggregateException($"{nameof(pm10IndexLevel)} can't be less than zero");
            if (string.IsNullOrEmpty(pm10IndexName))
                throw new ArgumentNullException(nameof(pm10IndexName));
            if (pm25IndexLevel < 0)
                throw new AggregateException($"{nameof(pm25IndexLevel)} can't be less than zero");
            if (string.IsNullOrEmpty(pm25IndexName))
                throw new ArgumentNullException(nameof(pm25IndexName));
            if (o3IndexLevel < 0)
                throw new AggregateException($"{nameof(o3IndexLevel)} can't be less than zero");
            if (string.IsNullOrEmpty(o3IndexName))
                throw new ArgumentNullException(nameof(o3IndexName));
            if (airHistory == null)
                throw new ArgumentNullException(nameof(airHistory));

            Id = Guid.NewGuid();
            StationId = stationId;
            CalcDate = calcDate;
            DownloadDate = downloadDate;
            So2IndexLevel = so2IndexLevel;
            So2IndexName = so2IndexName;
            No2IndexLevel = no2IndexLevel;
            No2IndexName = no2IndexName;
            Pm10IndexLevel = pm10IndexLevel;
            Pm10IndexName = pm10IndexName;
            Pm25IndexLevel = pm25IndexLevel;
            Pm25IndexName = pm25IndexName;
            O3IndexLevel = o3IndexLevel;
            O3IndexName = o3IndexName;
            
            AirHistory = airHistory;
            AirHistoryId = airHistory.Id;
        }
    }
}