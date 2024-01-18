using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task CreateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(Usuario usuario);
    }
}
