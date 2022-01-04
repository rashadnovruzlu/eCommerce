using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class SubCategoryTranslationService : BaseEntityService<SubCategoryTranslation>, ISubCategoryTranslationService
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryTranslationRepository _repository;


        public SubCategoryTranslationService(IMapper mapper, ISubCategoryTranslationRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;

        }



        public IEnumerable<SubCategoryTranslationTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()

                        select new SubCategoryTranslationTableResponse
                        {
                            Id = o.Id,
                            Name = o.Name,
                            LanguageId = o.LanguageId,
                            SubCategoryId = o.SubCategoryId,

                        };

            return query;

        }
        public SubCategoryTranslationUpdateRequest GetForUpdateById(int id)
        {
            var entity = Get(id);
            var model = _mapper.Map<SubCategoryTranslationUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(SubCategoryTranslationUpdateRequest model)
        {
            var entity = _mapper.Map<SubCategoryTranslation>(model);

            await UpdateAsync(entity);


        }
        public void DeleteById(int id)
        {
            SubCategoryTranslation entity = new SubCategoryTranslation { Id = id };

            Delete(entity);
        }
        public async Task<SubCategoryTranslationDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<SubCategoryTranslationDTO>(entity);
        }

    }

}
