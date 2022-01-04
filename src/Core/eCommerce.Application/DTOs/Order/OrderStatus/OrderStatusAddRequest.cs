using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class OrderStatusAddRequest : BaseDTO, IMapTo<OrderStatus>
    {
        public string Name { get; set; }
        public ICollection<OrderStatusTranslationAddRequest> OrderStatusTranslations { get; set; }

    }
}