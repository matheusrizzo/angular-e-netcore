using Domain.Entities;
using Template.Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();

    }
}
