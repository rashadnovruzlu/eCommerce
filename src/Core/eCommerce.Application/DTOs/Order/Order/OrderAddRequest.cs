using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class OrderAddRequest : BaseDTO, IMapTo<Order>
    {
        public string TransactionCode { get; set; }
        public string OrderStatusIdHash { get; set; }
        [JsonIgnore]
        public int OrderStatusId { get { return Decrypt<int>(OrderStatusIdHash); } set { OrderStatusIdHash = Encrypt(value); } }
        public DateTime InsertDate { get; set; }
        public ICollection<OrderDetailAddRequest> OrderDetails { get; set; }

    }
}