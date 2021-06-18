using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// PermissionRepository.
    /// </summary>
    public class PermissionRepository : GenericRepository<Permissions>, IPermissionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public PermissionRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
