using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// RolePermissionRepository.
    /// </summary>
    public class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermissionRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public RolePermissionRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
