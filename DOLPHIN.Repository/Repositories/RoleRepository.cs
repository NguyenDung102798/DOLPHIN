using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// RoleRepository.
    /// </summary>
    public class RoleRepository : GenericRepository<Roles>, IRoleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public RoleRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
