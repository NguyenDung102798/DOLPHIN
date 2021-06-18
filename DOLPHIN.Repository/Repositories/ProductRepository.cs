using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// ProductRepository.
    /// </summary>
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public ProductRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
