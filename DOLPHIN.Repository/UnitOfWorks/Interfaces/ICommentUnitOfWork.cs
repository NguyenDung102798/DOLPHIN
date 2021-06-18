using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.UnitOfWorks.Interfaces
{
    /// <summary>
    /// Comment Unit Of Work.
    /// </summary>
    public interface ICommentUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets Comment Repository Contructor.
        /// </summary>
        ICommentRepository CommentRepository { get; }
    }
}
