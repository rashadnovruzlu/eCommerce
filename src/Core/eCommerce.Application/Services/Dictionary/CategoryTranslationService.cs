using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class CategoryTranslationService : BaseEntityService<CategoryTranslation>, ICategoryTranslationService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTranslationRepository _repository;


        public CategoryTranslationService(IMapper mapper, ICategoryTranslationRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;

        }



        public IEnumerable<CategoryTranslationTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()

                        select new CategoryTranslationTableResponse
                        {
                            Id = o.Id,
                            LanguageId = o.LanguageId,
                            CategoryId = o.CategoryId,
                            Name = o.Name,

                        };

            return query;

        }
        public CategoryTranslationUpdateRequest GetForUpdateById(int id)
        {
            var entity = Get(id);
            var model = _mapper.Map<CategoryTranslationUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(CategoryTranslationUpdateRequest model)
        {
            var entity = _mapper.Map<CategoryTranslation>(model);

            await UpdateAsync(entity);


        }
        public void DeleteById(int id)
        {
            CategoryTranslation entity = new CategoryTranslation { Id = id };

            Delete(entity);
        }
        public async Task<CategoryTranslationDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<CategoryTranslationDTO>(entity);
        }

    }

}
