using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.UnitOfWorks.Interfaces
{
    /// <summary>
    /// User Unit Of Work Interface.
    /// </summary>
    public interface IUserUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets User Repository Contructor.
        /// </summary>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// Gets RoleUser Repository.
        /// </summary>
        IRoleUserRepository RoleUserRepository { get; }

        /// <summary>
        /// Gets RolePermision Repository.
        /// </summary>
        IRolePermissionRepository RolePermissionRepository { get; }
    }
}
