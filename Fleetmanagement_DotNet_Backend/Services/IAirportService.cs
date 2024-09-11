namespace Fleetmanagement_new.Services
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> GetAllAirportsAsync();
        Task<Airport> GetAirportById(long airportId);
        Task<Airport> PostAirport(Airport airport);
        Task<Airport> PutAirport(long airportId, Airport airport);
        Task<bool> DeleteAirport(long airportId);
    }
}
