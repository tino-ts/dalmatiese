using Dalmatiese.Domain.Entities;

namespace Dalmatiese.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}