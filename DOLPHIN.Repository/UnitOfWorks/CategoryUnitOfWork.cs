using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;
using DOLPHIN.Repository.Repositories;
using DOLPHIN.Repository.UnitOfWorks.Interfaces;

namespace DOLPHIN.Repository.UnitOfWorks
{
    /// <summary>
    /// CategoryUnitOfWork.
    /// </summary>
    public class CategoryUnitOfWork : UnitOfWorkBase, ICategoryUnitOfWork
    {
        private ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryUnitOfWork"/> class.
        /// </summary>
        /// <param name="dbcontext">dbcontext.</param>
        public CategoryUnitOfWork(IDbContext dbcontext)
            : base(dbcontext)
        {
        }

        /// <inheritdoc/>
        public ICategoryRepository CategoryRepository => this.categoryRepository ?? (this.categoryRepository = new CategoryRepository(this.dbContext));
    }
}
