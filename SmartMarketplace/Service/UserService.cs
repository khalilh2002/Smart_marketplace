using SmartMarketplace.Models;
using SmartMarketplace.Repository.Interface;
using SmartMarketplace.Service.Interface;
namespace SmartMarketplace.Service;

public class UserService : IUserService
{
  private readonly IUserRepository _repository;

  public UserService(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<User>> GetAll()
  {
    return await _repository.GetAllAsync();
  }
}
