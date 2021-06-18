using AutoMapper;
using DOLPHIN.DTO;
using DOLPHIN.Helpers;
using DOLPHIN.Model;
using DOLPHIN.Repository.UnitOfWorks.Interfaces;
using DOLPHIN.Service.Common;
using DOLPHIN.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOLPHIN.Service.Services
{
    /// <summary>
    /// CategoryService.
    /// </summary>
    public class CategoryService : EntityService<Categories>, ICategoryService
    {
        private readonly ICategoryUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// CategoryService.
        /// </summary>
        /// <param name="unitOfWork">unitOfWork.</param>
        /// <param name="mapper">mapper.</param>
        public CategoryService(ICategoryUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.CategoryRepository)
        {
            Guard.IsNotNull(mapper, nameof(mapper));
            Guard.IsNotNull(unitOfWork, nameof(unitOfWork));

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> CreateCategory(CategoriesDto categoryDto, Guid currentUserId)
        {
            if (categoryDto == null)
            {
                return false;
            }

            var category = this.mapper.Map<Categories>(categoryDto);
            category.CreatedById = currentUserId;
            category.CreatedDate = DateTime.Now;

            await this.unitOfWork.CategoryRepository.Add(category);
            return await this.unitOfWork.Commit() > 0;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            if (categoryId == null)
            {
                return false;
            }

            var category = await this.unitOfWork.CategoryRepository.GetCategoryById(categoryId);

            await this.unitOfWork.CategoryRepository.Delete(category);
            return await this.unitOfWork.Commit() > 0;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CategoriesDto>> GetAllCategories()
        {
            var categories = (await this.unitOfWork.CategoryRepository.GetAll())
                .Select(c => this.mapper.Map<CategoriesDto>(c));
            return categories;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateCategory(CategoriesDto categoryDto, Guid currentUserId)
        {
            if (categoryDto == null)
            {
                return false;
            }

            var category = await this.unitOfWork.CategoryRepository.GetCategoryById(categoryDto.Id);

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;

            await this.unitOfWork.CategoryRepository.Edit(category);

            return await this.unitOfWork.Commit() > 0;
        }
    }
}
