using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;

namespace DOLPHIN.Repository.UnitOfWorks.Interfaces
{
    /// <summary>
    /// Interface Order Unit Of Work.
    /// </summary>
    public interface IOrderUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets Order Repository.
        /// </summary>
        IOrderRepository OrderRepository { get; }

        /// <summary>
        /// Gets Order Detail Repository.
        /// </summary>
        IOrderDetailRepository OrderDetailRepository { get; }

        /// <summary>
        /// Gets get ProductRepository.
        /// </summary>
        IProductRepository ProductRepository { get; }
    }
}
