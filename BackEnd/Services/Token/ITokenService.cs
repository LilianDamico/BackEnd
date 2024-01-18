using BackEnd.Models;

namespace BackEnd.Services.Token
{
    public interface ITokenService
    {
        string GerarToken(string key, string issuer, string audience, Usuario usuario);
    }
}
