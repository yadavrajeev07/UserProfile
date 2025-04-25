// Services/ILocationService.cs
using userprofileapp.Models;
public interface ILocationService
{
    Task<List<Country>> GetCountriesAsync();
    Task<List<State>> GetStatesByCountryIdAsync(string countryId);
}

// Services/LocationService.cs
public class LocationService : ILocationService
{
    private readonly List<Country> _countries = new()
    {
        new Country { Id = "1", Name = "India" },
        new Country { Id = "2", Name = "USA" }
    };

    private readonly List<State> _states = new()
    {
        new State { Id = "1", Name = "Uttar Pradesh", CountryId = "1" },
        new State { Id = "2", Name = "Maharashtra", CountryId = "1" },
        new State { Id = "3", Name = "California", CountryId = "2" },
        new State { Id = "4", Name = "Texas", CountryId = "2" }
    };

    public Task<List<Country>> GetCountriesAsync() => Task.FromResult(_countries);
    public Task<List<State>> GetStatesByCountryIdAsync(string countryId) =>
        Task.FromResult(_states.Where(s => s.CountryId == countryId).ToList());
}
