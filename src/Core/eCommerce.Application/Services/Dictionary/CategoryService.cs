using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class CategoryService : BaseEntityService<Category>, ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        private readonly ICategoryTranslationRepository _categoryTranslationRepository;

        public CategoryService(IMapper mapper, ICategoryRepository repository, ICategoryTranslationRepository categoryTranslationRepository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
            _categoryTranslationRepository = categoryTranslationRepository;

        }



        public IEnumerable<DropDownDto> GetList()
        {
            return _repository.GetAllWithTranslation().Select(x => new DropDownDto
            {
                Value = x.Id,
                DisplayText = x.Name
            }).ToList();

        }
        public IEnumerable<DropDownDto> GetPageableList(DropdownRequest request)
        {
            var query = _repository.GetAllWithTranslation();

            return Filter(
                    query,
                    x => x.Name.StartsWith(request.SearchKey),
                    null, request.Page, request.PageSize).
                Select(x => new DropDownDto
                {
                    Value = x.Id,
                    DisplayText = x.Name
                }).ToList();
        }
        public IEnumerable<CategoryTableResponse> GetTable()
        {
            var query = from o in _repository.GetAllWithTranslation()

                        select new CategoryTableResponse
                        {
                            Id = o.Id,
                            Name = o.Name,
                            IsDeleted = o.IsDeleted,

                        };

            return query;

        }
        public CategoryUpdateRequest GetForUpdateById(int id)
        {
            var entity = IncludeMany(x => x.Id == id, x => x.CategoryTranslations).SingleOrDefault();
            var model = _mapper.Map<CategoryUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(CategoryUpdateRequest model)
        {
            var entity = _mapper.Map<Category>(model);

            await UpdateAsync(entity);


            foreach (var id in model.DeletedCategoryTranslations)
            {
                var deleted = new CategoryTranslation { Id = id };

                _categoryTranslationRepository.Delete(deleted);
            }
        }
        public void DeleteById(int id)
        {
            Category entity = new Category { Id = id, IsDeleted = false };

            UpdateSpecialProperties(entity, true, x => x.IsDeleted);
        }
        public async Task<CategoryDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<CategoryDTO>(entity);
        }

    }

}
