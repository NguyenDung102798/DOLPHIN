using DOLPHIN.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOLPHIN.Helpers.Interfaces
{
    public interface ICallApiGHNHelper 
    {
        Task<string> GetProvince(string token);

        Task<string> GetDistrict(string token, int provinceId);
        Task<string> GetWard(string token, int districtId);
        Task<string> CreateOrder(string token, OrderRequestDto orderRequestDto);
        Task<string> TrackingOrders(string orderCode);
        Task<string> TrackingOrdersByClient(string clientOrderCode);
        Task<string> UpdateOrders(OrderRequestDto orderRequestDto);
        Task<string> PrintOrder(string orderCode);
    }
}
