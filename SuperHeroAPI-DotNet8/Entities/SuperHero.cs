using System;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI_DotNet8.Entities;

public class SuperHero
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The name field is required")]
    public string Name { get; set; } 
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Place { get; set; } = String.Empty;
}