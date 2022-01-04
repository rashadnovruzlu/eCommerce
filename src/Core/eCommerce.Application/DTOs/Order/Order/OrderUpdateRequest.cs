using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class OrderUpdateRequest : BaseDTO, IMapTo<Order>
    {
        public string IdHash { get; set; }
        [JsonIgnore]
        public int Id { get { return Decrypt<int>(IdHash); } set { IdHash = Encrypt(value); } }
        public string TransactionCode { get; set; }
        public string OrderStatusIdHash { get; set; }
        [JsonIgnore]
        public int OrderStatusId { get { return Decrypt<int>(OrderStatusIdHash); } set { OrderStatusIdHash = Encrypt(value); } }
        public DateTime InsertDate { get; set; }
        public ICollection<OrderDetailUpdateRequest> OrderDetails { get; set; }
        public int[] DeletedOrderDetails { get; set; }

    }
}