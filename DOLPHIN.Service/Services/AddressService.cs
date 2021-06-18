using DOLPHIN.DTO;
using DOLPHIN.Helpers.Interfaces;
using DOLPHIN.Service.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOLPHIN.Service.Services
{
    /// <summary>
    /// AddressService.
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly ICallApiGHNHelper callApiGHNHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressService"/> class.
        /// </summary>
        /// <param name="callApiGHNHelper">callApiGHNHelper.</param>
        public AddressService(ICallApiGHNHelper callApiGHNHelper)
        {
            this.callApiGHNHelper = callApiGHNHelper;
        }

        /// <inheritdoc/>
        public async Task<List<AddressViewDto>> GetProvince(string token)
        {
            var response = await this.callApiGHNHelper.GetProvince(token);
            var result = JsonConvert.DeserializeObject<dynamic>(response);
            var province = new List<AddressViewDto>();

            foreach (var item in result?.data)
            {
                province.Add(new AddressViewDto
                {
                    Code = item.Code,
                    ProvinceID = item.ProvinceID,
                    ProvinceName = item.ProvinceName,
                });
            }

            return province;
        }

        public async Task<List<DistrictViewDto>> GetDistrict(string token, int provinceId)
        {
            var response = await this.callApiGHNHelper.GetDistrict(token, provinceId);
            var result = JsonConvert.DeserializeObject<dynamic>(response);
            var districts = new List<DistrictViewDto>();

            foreach (var item in result?.data)
            {
                districts.Add(new DistrictViewDto
                {
                    DistrictID = item.DistrictID,
                    ProvinceID = item.ProvinceID,
                    DistrictName = item.DistrictName,
                    Code = item.Code,
                    Type = item.Type,
                    SupportType = item.SupportType
                });
            }

            return districts;
        }

        public async Task<List<WardViewDto>> GetWard(string token, int districtId)
        {
            var response = await this.callApiGHNHelper.GetWard(token, districtId);
            var result = JsonConvert.DeserializeObject<dynamic>(response);
            var wards = new List<WardViewDto>();

            foreach (var item in result?.data)
            {
                wards.Add(new WardViewDto
                {
                    WardCode = item.WardCode,
                    DistrictID = item.DistrictID,
                    WardName = item.WardName
                });
            }

            return wards;
        }

        public async Task<List<OrderViewDto>> CreateOrder(string token, OrderRequestDto orderRequestDto)
        {
            var response = await this.callApiGHNHelper.CreateOrder(token, orderRequestDto);
            var result = JsonConvert.DeserializeObject<dynamic>(response);
            var orders = new List<OrderViewDto>();

            //orders.Add(new OrderViewDto
            //{
            //    ClientOrderCode = orderRequestDto.CliendOrderCode
            //});
            orders.Add(new OrderViewDto
            {
                ClientOrderCode = orderRequestDto.CliendOrderCode,
                OrderCode = result?.data?.order_code,
                SortCode = result?.data.sort_code,
                TotalFee = result?.data.total_fee,
                ExpectedDeliveryTime = result?.data.expected_delivery_time
            });

            return orders;
        }

        public async Task<List<TrackingOrderViewDto>> TrackingOrders(string orderCode)
        {
            var response = await this.callApiGHNHelper.TrackingOrdersByClient(orderCode);
            var result = JsonConvert.DeserializeObject<dynamic>(response);
            var trackingOrders = new List<TrackingOrderViewDto>();

            trackingOrders.Add(new TrackingOrderViewDto
            {
                Status = result.data.status, 
                ToName = result.data.to_name,
                ToAddress = result.data.to_address,
                ToPhone = result.data.to_phone                
            });

            return trackingOrders;
        }
        public async Task<List<OrderInfoDto>> OrderInfo(string orderCode)
        {
            var response = await this.callApiGHNHelper.TrackingOrders(orderCode);
            var result = JsonConvert.DeserializeObject<dynamic>(response);
            var orderInfo = new List<OrderInfoDto>();
            var logOrders = new List<LogsOrderDto>();
            logOrders.Add(new LogsOrderDto
            {
                Status = "Chưa in mã vận đơn"
            });
            if (result.data.log != null)
            {
                foreach (var logs in result.data.log)
                {
                    logOrders.Add(new LogsOrderDto
                    {
                        Status = logs.status,
                        UpdateDate = logs.updated_date
                    });
                }
            }
            
            orderInfo.Add(new OrderInfoDto
            {
                Name = result.data.to_name,
                Address = result.data.to_address,
                Phone = result.data.to_phone,
                logsOrderDtos = logOrders
            });

            return orderInfo;
        }
    }
}
