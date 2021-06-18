using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// CommentRepository.
    /// </summary>
    public class CommentRepository : GenericRepository<Comments>, ICommentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public CommentRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
