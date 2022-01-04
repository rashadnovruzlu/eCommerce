using eCommerce.Domain.Entities;
using eCommerce.Application.Interfaces;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs
{

#nullable disable
    public class CategoryAddRequest : BaseDTO, IMapTo<Category>
    {
        public string Name { get; set; }
        public ICollection<CategoryTranslationAddRequest> CategoryTranslations { get; set; }

    }
}