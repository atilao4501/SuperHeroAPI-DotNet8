using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroAPI_DotNet8.Entities;

public class Agency
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public List<SuperHero> SuperHeroes { get; set; }
}