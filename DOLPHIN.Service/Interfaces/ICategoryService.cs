using DOLPHIN.DTO;
using DOLPHIN.Model;
using DOLPHIN.Service.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOLPHIN.Service.Interfaces
{
    /// <summary>
    /// Interface Category Service.
    /// </summary>
    public interface ICategoryService : IEntityService<Categories>
    {

        /// <summary>
        /// GetAllCategories.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<CategoriesDto>> GetAllCategories();

        /// <summary>
        /// Create Category.
        /// </summary>
        /// <param name="categoryDto">categoryDto.</param>
        /// <param name="currentUserId">currentUserId.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> CreateCategory(CategoriesDto categoryDto, Guid currentUserId);

        /// <summary>
        /// Update Category.
        /// </summary>
        /// <param name="categoryDto">categoryDto.</param>
        /// <param name="currentUserId">currentUserId.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> UpdateCategory(CategoriesDto categoryDto, Guid currentUserId);

        /// <summary>
        /// Delete Category.
        /// </summary>
        /// <param name="categoryId">categoryId.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> DeleteCategory(Guid categoryId);
    }
}
