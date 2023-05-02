using Dalmatiese.Domain.Entities;

namespace Dalmatiese.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}