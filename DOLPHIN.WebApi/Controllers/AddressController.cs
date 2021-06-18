using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOLPHIN.DTO;
using DOLPHIN.Service.Interfaces;
using DOLPHIN.WebApi.Enums;
using DOLPHIN.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace DOLPHIN.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;
        public AddressController(
            IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet("GetProvince")]
        public async Task<ApiResponse<List<AddressViewDto>>> GetProvince()
        {
            try
            {
                string token = "98bb7369-1162-11eb-a23c-065c95c021cb";
                return new ApiResponse<List<AddressViewDto>>(EnStatusApiReponse.Success, await this.addressService.GetProvince(token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("GetDistrict")]
        public async Task<ApiResponse<List<DistrictViewDto>>> GetDistrict(int provinceId)
        {
            try
            {
                string token = "98bb7369-1162-11eb-a23c-065c95c021cb";
                return new ApiResponse<List<DistrictViewDto>>(EnStatusApiReponse.Success, await this.addressService.GetDistrict(token, provinceId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("GetWard")]
        public async Task<ApiResponse<List<WardViewDto>>> GetWard(int districtId)
        {
            try
            {
                string token = "98bb7369-1162-11eb-a23c-065c95c021cb";
                return new ApiResponse<List<WardViewDto>>(EnStatusApiReponse.Success, await this.addressService.GetWard(token, districtId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("CreateOrder")]
        public async Task<ApiResponse<List<OrderViewDto>>> CreateOrder(OrderRequestDto orderRequestDto)
        {
            try
            {
                string token = "98bb7369-1162-11eb-a23c-065c95c021cb";
                return new ApiResponse<List<OrderViewDto>>(EnStatusApiReponse.Success, await this.addressService.CreateOrder(token, orderRequestDto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
