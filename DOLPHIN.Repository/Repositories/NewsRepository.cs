using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// NewsRepository.
    /// </summary>
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public NewsRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
