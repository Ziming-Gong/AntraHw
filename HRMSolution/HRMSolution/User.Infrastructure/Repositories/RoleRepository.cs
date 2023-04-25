using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Entity;
using User.Infrastructure.Data;

namespace User.Infrastructure.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(UserDbContext context) : base(context)
    {
        
    }
    
}