// Models/Country.cs
public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
}

// Models/State.cs
public class State
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CountryId { get; set; }
}
