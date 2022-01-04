using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class SubCategoryService : BaseEntityService<SubCategory>, ISubCategoryService
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryRepository _repository;

        private readonly ISubCategoryTranslationRepository _subCategoryTranslationRepository;

        public SubCategoryService(IMapper mapper, ISubCategoryRepository repository, ISubCategoryTranslationRepository subCategoryTranslationRepository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
            _subCategoryTranslationRepository = subCategoryTranslationRepository;

        }



        public IEnumerable<DropDownDto> GetList()
        {
            return _repository.GetAllWithTranslation().Select(x => new DropDownDto
            {
                Value = x.Id,
                DisplayText = x.Name
            }).ToList();

        }
        public IEnumerable<DropDownDto> GetListByCategoryId(int categoryId)
        {
            return _repository.GetAllWithTranslation().Where(x => x.CategoryId == categoryId).Select(x => new DropDownDto
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
        public IEnumerable<DropDownDto> GetPageableListByCategoryId(DropdownRequest request)
        {
            var query = _repository.GetAllWithTranslation();

            query = query.Where(x => x.CategoryId == request.DependentColumnId);

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

        public IEnumerable<SubCategoryDTO> GetTableByCategoryId(int categoryId)
        {
            return _repository.GetAll().Where(x => x.CategoryId == categoryId).Select(entity => new SubCategoryDTO
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                IsDeleted = entity.IsDeleted,


            }).ToList();

        }
        public IEnumerable<SubCategoryTableResponse> GetTable()
        {
            var query = from o in _repository.GetAllWithTranslation()

                        select new SubCategoryTableResponse
                        {
                            Id = o.Id,
                            CategoryId = o.CategoryId,
                            Name = o.Name,
                            IsDeleted = o.IsDeleted,

                        };

            return query;

        }
        public SubCategoryUpdateRequest GetForUpdateById(int id)
        {
            var entity = IncludeMany(x => x.Id == id, x => x.SubCategoryTranslations).SingleOrDefault();
            var model = _mapper.Map<SubCategoryUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(SubCategoryUpdateRequest model)
        {
            var entity = _mapper.Map<SubCategory>(model);

            await UpdateAsync(entity);


            foreach (var id in model.DeletedSubCategoryTranslations)
            {
                var deleted = new SubCategoryTranslation { Id = id };

                _subCategoryTranslationRepository.Delete(deleted);
            }
        }
        public void DeleteById(int id)
        {
            SubCategory entity = new SubCategory { Id = id, IsDeleted = false };

            UpdateSpecialProperties(entity, true, x => x.IsDeleted);
        }
        public async Task<SubCategoryDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<SubCategoryDTO>(entity);
        }

    }

}
