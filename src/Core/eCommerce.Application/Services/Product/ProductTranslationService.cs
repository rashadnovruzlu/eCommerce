using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class ProductTranslationService : BaseEntityService<ProductTranslation>, IProductTranslationService
    {
        private readonly IMapper _mapper;
        private readonly IProductTranslationRepository _repository;


        public ProductTranslationService(IMapper mapper, IProductTranslationRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;

        }



        public IEnumerable<ProductTranslationTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()

                        select new ProductTranslationTableResponse
                        {
                            Id = o.Id,
                            LanguageId = o.LanguageId,
                            ProductId = o.ProductId,
                            Name = o.Name,
                            Description = o.Description,

                        };

            return query;

        }
        public ProductTranslationUpdateRequest GetForUpdateById(int id)
        {
            var entity = Get(id);
            var model = _mapper.Map<ProductTranslationUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(ProductTranslationUpdateRequest model)
        {
            var entity = _mapper.Map<ProductTranslation>(model);

            await UpdateAsync(entity);


        }
        public void DeleteById(int id)
        {
            ProductTranslation entity = new ProductTranslation { Id = id };

            Delete(entity);
        }
        public async Task<ProductTranslationDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<ProductTranslationDTO>(entity);
        }

    }

}
