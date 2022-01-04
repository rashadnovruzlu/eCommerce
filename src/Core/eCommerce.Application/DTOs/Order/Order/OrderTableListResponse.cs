using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class OrderTableListResponse : BaseDTO
    {
        public int Count { get; set; }
        public ICollection<OrderTableResponse> Data { get; set; }

    }
}