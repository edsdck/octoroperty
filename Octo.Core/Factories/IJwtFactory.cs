using Octo.Core.Entities;

namespace Octo.Core.Factories
{
    public interface IJwtFactory
    {
        string GenerateJwtToken(OctoUser user);
    }
}