using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// CategoryRepository.
    /// </summary>
    public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public CategoryRepository(IDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// GetCategoryById.
        /// </summary>
        /// <param name="categoryId">categoryId.</param>
        /// <returns>category.</returns>
        public async Task<Categories> GetCategoryById(Guid categoryId)
        {
            return await this.dbset.Where(c => c.Id == categoryId).FirstOrDefaultAsync();
        }
    }
}
