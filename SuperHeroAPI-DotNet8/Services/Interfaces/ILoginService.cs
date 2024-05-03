using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Services.Interfaces;

public interface ILoginService
{
    public string CreateToken(Agency agency);
    
}