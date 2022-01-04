using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class BrandDTO : BaseDTO, IMapTo<Brand>
    {
        public string IdHash { get; set; }
        [JsonIgnore]
        public int Id { get { return Decrypt<int>(IdHash); } set { IdHash = Encrypt(value); } }
        public string CountryIdHash { get; set; }
        [JsonIgnore]
        public int CountryId { get { return Decrypt<int>(CountryIdHash); } set { CountryIdHash = Encrypt(value); } }
        public string Name { get; set; }

    }
}