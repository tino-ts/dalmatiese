using Dalmatiese.Domain.Entities;

namespace Dalmatiese.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);