using SmartMarketplace.Models;

namespace SmartMarketplace.Service.Interface;

public interface IUserService
{
  public Task<IEnumerable<User>> GetAll();

}
