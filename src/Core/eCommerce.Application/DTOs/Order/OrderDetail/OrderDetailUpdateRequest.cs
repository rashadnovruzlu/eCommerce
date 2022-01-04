using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class OrderDetailUpdateRequest : BaseDTO, IMapTo<OrderDetail>
    {
        public string IdHash { get; set; }
        [JsonIgnore]
        public int Id { get { return Decrypt<int>(IdHash); } set { IdHash = Encrypt(value); } }
        public string OrderIdHash { get; set; }
        [JsonIgnore]
        public int OrderId { get { return Decrypt<int>(OrderIdHash); } set { OrderIdHash = Encrypt(value); } }
        public string ProductIdHash { get; set; }
        [JsonIgnore]
        public int ProductId { get { return Decrypt<int>(ProductIdHash); } set { ProductIdHash = Encrypt(value); } }
        public int Price { get; set; }
        public int Count { get; set; }

    }
}