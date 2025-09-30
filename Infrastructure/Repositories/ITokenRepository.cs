using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(User user, string roleName);
    }
}
