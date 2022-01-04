using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class CategoryDTO : BaseDTO, IMapTo<Category>
    {
        public string IdHash { get; set; }
        [JsonIgnore]
        public int Id { get { return Decrypt<int>(IdHash); } set { IdHash = Encrypt(value); } }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

    }
}