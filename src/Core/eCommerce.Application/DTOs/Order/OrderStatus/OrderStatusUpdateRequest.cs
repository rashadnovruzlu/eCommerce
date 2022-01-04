using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class OrderStatusUpdateRequest : BaseDTO, IMapTo<OrderStatus>
    {
        public string IdHash { get; set; }
        [JsonIgnore]
        public int Id { get { return Decrypt<int>(IdHash); } set { IdHash = Encrypt(value); } }
        public string Name { get; set; }
        public ICollection<OrderStatusTranslationUpdateRequest> OrderStatusTranslations { get; set; }
        public int[] DeletedOrderStatusTranslations { get; set; }

    }
}