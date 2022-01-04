using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class ProductTranslationTableResponse : BaseDTO
    {
        public string IdHash { get; set; }
        [JsonIgnore]
        public int Id { get { return Decrypt<int>(IdHash); } set { IdHash = Encrypt(value); } }
        public string LanguageIdHash { get; set; }
        [JsonIgnore]
        public int LanguageId { get { return Decrypt<int>(LanguageIdHash); } set { LanguageIdHash = Encrypt(value); } }
        public string ProductIdHash { get; set; }
        [JsonIgnore]
        public int ProductId { get { return Decrypt<int>(ProductIdHash); } set { ProductIdHash = Encrypt(value); } }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}