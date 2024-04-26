using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI_DotNet8.Entities;

public class SuperHero
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Place { get; set; } = String.Empty;
    
    public Agency Agency { get; set; }
    
}