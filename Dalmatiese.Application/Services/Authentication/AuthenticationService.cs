using Dalmatiese.Application.Common.Interfaces.Authentication;
using Dalmatiese.Application.Common.Interfaces.Persistence;
using Dalmatiese.Domain.Entities;

namespace Dalmatiese.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with the given email does not exist.");
        }

        if(user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //validate user doesnt exist
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("UUser with the given email address exists.");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}