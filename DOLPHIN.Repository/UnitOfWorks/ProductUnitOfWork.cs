using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;
using DOLPHIN.Repository.Repositories;
using DOLPHIN.Repository.UnitOfWorks.Interfaces;

namespace DOLPHIN.Repository.UnitOfWorks
{
    /// <summary>
    /// ProductUnitOfWork.
    /// </summary>
    public class ProductUnitOfWork : UnitOfWorkBase, IProductUnitOfWork
    {
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderDetailRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductUnitOfWork"/> class.
        /// </summary>
        /// <param name="dbcontext">dbcontext.</param>
        public ProductUnitOfWork(IDbContext dbcontext)
            : base(dbcontext)
        {
        }

        /// <inheritdoc/>
        public IProductRepository ProductRepository => this.productRepository ?? (this.productRepository = new ProductRepository(this.dbContext));

        /// <inheritdoc/>
        public IOrderRepository OrderRepository => this.orderRepository ?? (this.orderRepository = new OrderRepository(this.dbContext));

        /// <inheritdoc/>
        public IOrderDetailRepository OrderDetailRepository => this.orderDetailRepository ?? (this.orderDetailRepository = new OrderDetailRepository(this.dbContext));
    }
}
