using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.DTO
{
    public class OrderRequestDto
    {
        /// <summary>
        /// Gets or sets Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets Shop ID.
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// Gets or sets Client Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Phone Number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets Ward Code from API GetWard.
        /// </summary>
        public string WardCode { get; set; }

        /// <summary>
        /// Gets or sets DistrictId from API GetDistrict.
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// Gets or sets Contact phone number to return parcels.
        /// </summary>
        public string ReturnPhone { get; set; }

        /// <summary>
        /// Gets or sets Address return parcels.
        /// </summary>
        public string ReturnAddress { get; set; }

        /// <summary>
        /// Gets or sets District ID return parcels. Use API GetDistricts.
        /// </summary>
        public int ReturnDistrictId { get; set; }

        /// <summary>
        /// Gets or sets Ward Code return parcels.Use API Get Ward.
        /// </summary>
        public string ReturnWardCode { get; set; }

        /// <summary>
        /// Gets or sets External order code managed by logged client [Unique field].
        /// </summary>
        public string CliendOrderCode { get; set; }

        /// <summary>
        /// Gets or sets Amount cash to collect.
        /// </summary>
        public int CodAmount { get; set; }

        /// <summary>
        /// Gets or sets Content for Order.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets Weight (gram).
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets Length (cm).
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets Width (cm).
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets Height (cm).
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets Choose who pay shipping fee.1 Shop/Seller    2. Buyer/Consignee.
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets Note shipping order : CHOTHUHANG, CHOXEMHANGKHONGTHU, KHONGCHOXEMHANG
        /// </summary>
        public string RequiredNote { get; set; }

        /// <summary>
        /// Gets or sets OrderCode.
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets Note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        public ItemsDto Items { get; set; }
    }
}
