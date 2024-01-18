using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IManagementService
    {
        Task<IEnumerable<Management>> GetManagements();
        Task<Management> GetManagement(int id);
        Task CreateManagement(Management management);
        Task DeleteManagement(Management management);
        Task UpdateManagement(Management management);
    }
}
