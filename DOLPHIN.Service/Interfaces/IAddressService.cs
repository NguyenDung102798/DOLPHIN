using DOLPHIN.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOLPHIN.Service.Interfaces
{
    public interface IAddressService
    {
        Task<List<AddressViewDto>> GetProvince(string token);
        Task<List<DistrictViewDto>> GetDistrict(string token, int provinceId);
        Task<List<WardViewDto>> GetWard(string token, int districtId);
        Task<List<OrderViewDto>> CreateOrder(string token, OrderRequestDto orderRequestDto);
        Task<List<TrackingOrderViewDto>> TrackingOrders(string orderCode);
        Task<List<OrderInfoDto>> OrderInfo(string orderCode);
    }
}
