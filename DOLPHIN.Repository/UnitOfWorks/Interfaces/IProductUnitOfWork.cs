using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.UnitOfWorks.Interfaces
{
    /// <summary>
    /// Interface Product Unit Of Work.
    /// </summary>
    public interface IProductUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets Role Repository Contructor.
        /// </summary>
        IProductRepository ProductRepository { get; }

        /// <summary>
        /// Gets Order Repository.
        /// </summary>
        IOrderRepository OrderRepository { get; }

        /// <summary>
        /// Gets Order Detail Repository.
        /// </summary>
        IOrderDetailRepository OrderDetailRepository { get; }
    }
}
