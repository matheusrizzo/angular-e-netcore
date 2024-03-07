using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Template.Data.Repositories;

namespace Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(TemplateContext context)
            : base(context) { }

        public IEnumerable<User> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}