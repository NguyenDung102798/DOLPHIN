using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// OrderRepository.
    /// </summary>
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public OrderRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
