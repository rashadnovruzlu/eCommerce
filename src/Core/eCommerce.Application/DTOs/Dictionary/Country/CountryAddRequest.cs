using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class CountryAddRequest : BaseDTO, IMapTo<Country>
    {
        public string Name { get; set; }

    }
}