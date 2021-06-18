using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// OrderDetailRepository.
    /// </summary>
    public class OrderDetailRepository : GenericRepository<OrderDetails>, IOrderDetailRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public OrderDetailRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
