using AutoMapper;
using DOLPHIN.DTO;
using DOLPHIN.Helpers;
using DOLPHIN.Model;
using DOLPHIN.Repository.UnitOfWorks.Interfaces;
using DOLPHIN.Service.Common;
using DOLPHIN.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOLPHIN.Service.Services
{
    public class StatisticService : EntityService<Orders>, IStatisticService
    {
        private readonly IOrderUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// CategoryService.
        /// </summary>
        /// <param name="unitOfWork">unitOfWork.</param>
        /// <param name="mapper">mapper.</param>
        public StatisticService(IOrderUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, unitOfWork.OrderRepository)
        {
            Guard.IsNotNull(mapper, nameof(mapper));
            Guard.IsNotNull(unitOfWork, nameof(unitOfWork));

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<StatisticsDto> GetStatistics()
        {
            var statistics = new StatisticsDto();
            // Count this orders of shop
            var orders = await this.unitOfWork.OrderRepository.GetAll();
            // Get Products
            var products = await this.unitOfWork.ProductRepository.GetAll();
            // Get Total Sales
            var orderDetail = await this.unitOfWork.OrderDetailRepository.GetAll();
            return statistics;
        }
    }
}
