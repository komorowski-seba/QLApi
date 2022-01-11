using Domain.Common;

namespace Domain.Entities.AirAnalysisContext;

public class AirTestHistory : IAggregateRoot
{
    public Guid Id { get; init; }
    public DateTime UpdateDate { get; private set; }
    public long StationId { get; init; }
    public Guid? LastTestId { get; private set; }
    
    private readonly List<AirTest> _airTests;
    public IReadOnlyCollection<AirTest> AirTests => _airTests;

    public AirTestHistory()
    {
        _airTests = new List<AirTest>();
    }
    
    public AirTestHistory(long stationId,
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
        string o3IndexName)
    {
        Id = Guid.NewGuid();
        StationId = stationId;
        _airTests = new List<AirTest>();

        AddAirTest(stationId, calcDate, downloadDate,
            so2IndexLevel, so2IndexName, no2IndexLevel, no2IndexName,
            pm10IndexLevel, pm10IndexName, pm25IndexLevel, pm25IndexName,
            o3IndexLevel, o3IndexName);
    }

    public AirTest AddAirTest(long stationId,
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
        string o3IndexName)
    {
        var airTest = new AirTest(stationId,
            calcDate,
            downloadDate,
            so2IndexLevel,
            so2IndexName,
            no2IndexLevel,
            no2IndexName,
            pm10IndexLevel,
            pm10IndexName,
            pm25IndexLevel,
            pm25IndexName,
            o3IndexLevel,
            o3IndexName,
            this);

        _airTests.Add(airTest);
        LastTestId = airTest.Id;
        UpdateDate = DateTime.UtcNow;

        return airTest;
    }
}