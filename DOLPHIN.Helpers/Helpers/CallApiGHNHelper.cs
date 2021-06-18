using DOLPHIN.DTO;
using DOLPHIN.Helpers.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DOLPHIN.Helpers.Helpers
{
    public class CallApiGHNHelper : ICallApiGHNHelper
    {
        private readonly IConfiguration configs;
        private readonly string ghnUrl;


        public CallApiGHNHelper(IConfiguration configs)
        {
            this.configs = configs;
            this.ghnUrl = this.configs["GhnUrl"];
        }

        public async Task<string> GetProvince(string token)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(ghnUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "98bb7369-1162-11eb-a23c-065c95c021cb");

            // List data response.
            var response = await client.GetAsync("/shiip/public-api/master-data/province");
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetDistrict(string token, int provinceId)
        {
            var notiRequest = new
            {
                province_id = provinceId
            };
            var json = JsonConvert.SerializeObject(notiRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri(ghnUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "98bb7369-1162-11eb-a23c-065c95c021cb");

            // List data response.
            var response = await client.PostAsync("/shiip/public-api/master-data/district", data);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetWard(string token, int districtId)
        {
            var notiRequest = new
            {
                district_id = districtId
            };
            var json = JsonConvert.SerializeObject(notiRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri(ghnUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "98bb7369-1162-11eb-a23c-065c95c021cb");

            // List data response.
            var response = await client.PostAsync("/shiip/public-api/master-data/ward?district_id", data);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> CreateOrder(string token, OrderRequestDto orderRequestDto)
        {
            var notiRequest = new
            {
                shop_id = 75661,
                payment_type_id = 2,
                note = "",
                client_order_code = orderRequestDto.CliendOrderCode,
                required_note = "KHONGCHOXEMHANG",
                return_phone = "0368345905",
                return_address = "124 Ngô Quyền, Quang Trung, Hà Đông, Hà Nội",
                return_district_id = 1542,
                return_ward_code = "1B1513",
                to_name = orderRequestDto.Name,
                to_phone = orderRequestDto.Phone,
                to_address = orderRequestDto.Address,
                to_ward_code = orderRequestDto.WardCode,
                to_district_id = orderRequestDto.DistrictId,
                cod_amount = orderRequestDto.CodAmount,
                content = orderRequestDto.Content,
                service_id =53321,
                service_type_id = 2,
                weight = 500,
                length = 50,
                width = 50,
                height = 15,
                source = "5sao",
                items = new[] {
                    new {
                        name = orderRequestDto.Items.Name,
                        code = orderRequestDto.Items.Code,
                        quantity = orderRequestDto.Items.Quantity
                    }
                }
            };
            var json = JsonConvert.SerializeObject(notiRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://dev-online-gateway.ghn.vn/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "98bb7369-1162-11eb-a23c-065c95c021cb");
            client.DefaultRequestHeaders.Add("ShopId", "75661");

            // List data response.
            var response = await client.PostAsync("/shiip/public-api/v2/shipping-order/create", data);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> TrackingOrders(string orderCode)
        {
            var notiRequest = new
            {
                order_code = orderCode
            };
            var json = JsonConvert.SerializeObject(notiRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://dev-online-gateway.ghn.vn/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "98bb7369-1162-11eb-a23c-065c95c021cb");
            client.DefaultRequestHeaders.Add("ShopId", "75661");

            // List data response.
            var response = await client.PostAsync("/shiip/public-api/v2/shipping-order/detail", data);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> TrackingOrdersByClient(string clientOrderCode)
        {
            var notiRequest = new
            {
                client_order_code = clientOrderCode
            };
            var json = JsonConvert.SerializeObject(notiRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://dev-online-gateway.ghn.vn/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "98bb7369-1162-11eb-a23c-065c95c021cb");
            client.DefaultRequestHeaders.Add("ShopId", "75661");

            // List data response.
            var response = await client.PostAsync("/shiip/public-api/v2/shipping-order/detail-by-client-code", data);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
        public async Task<string> PrintOrder(string orderCode)
        {
            var notiRequest = new
            {
                order_codes = new[] {
                    new {
                        orderCode
                    }
                }
            };
            var json = JsonConvert.SerializeObject(notiRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://dev-online-gateway.ghn.vn/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "98bb7369-1162-11eb-a23c-065c95c021cb");

            // List data response.
            var response = await client.PostAsync("/shiip/public-api/v2/a5/gen-token", data);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
        public async Task<string> UpdateOrders(OrderRequestDto orderRequestDto)
        {
            var notiRequest = new
            {
                order_code = orderRequestDto.OrderCode,
                note = orderRequestDto.Note,
                to_name = orderRequestDto.Name,
                to_phone = orderRequestDto.Phone,
                to_address = orderRequestDto.Address,
                to_ward_code = orderRequestDto.WardCode,
                to_district_id = orderRequestDto.DistrictId,
                cod_amount = orderRequestDto.CodAmount,
                content = orderRequestDto.Content,
                source = "5sao",
                items = new[] {
                    new {
                        name = orderRequestDto.Items.Name,
                        code = orderRequestDto.Items.Code,
                        quantity = orderRequestDto.Items.Quantity
                    }
                }

            };
            var json = JsonConvert.SerializeObject(notiRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://dev-online-gateway.ghn.vn/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "98bb7369-1162-11eb-a23c-065c95c021cb");
            client.DefaultRequestHeaders.Add("ShopId", "75661");

            // List data response.
            var response = await client.PostAsync("/shiip/public-api/v2/shipping-order/update", data);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
        private async Task<StringContent> CreateRequest(int provinceId)
        {
            var notiRequest = new
            {
                province_id = provinceId
            };
            var json = JsonConvert.SerializeObject(notiRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }
    }
}
