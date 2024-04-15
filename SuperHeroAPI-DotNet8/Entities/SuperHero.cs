namespace SuperHeroAPI_DotNet8.Entities;

public class SuperHero
{
    public required int Id { get; set; }
    public required string Name { get; set; } 
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Place { get; set; } = String.Empty;
}