using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.UnitOfWorks.Interfaces
{
    /// <summary>
    /// Category Unit Of Work Interface.
    /// </summary>
    public interface ICategoryUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets Category Repository.
        /// </summary>
        ICategoryRepository CategoryRepository { get; }
    }
}
