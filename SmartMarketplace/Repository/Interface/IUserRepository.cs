using SmartMarketplace.Models;

namespace SmartMarketplace.Repository.Interface;

public interface IUserRepository
{
  public Task<User?> GetByEmailAsync(string email);


  public Task<User?> GetByIdAsync(int id);

  public Task<IEnumerable<User>> GetAllAsync();

  public Task Insert(User user);

}
