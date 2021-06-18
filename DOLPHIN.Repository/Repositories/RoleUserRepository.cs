using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// RoleUserRepository.
    /// </summary>
    public class RoleUserRepository : GenericRepository<RoleUser>, IRoleUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleUserRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public RoleUserRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
