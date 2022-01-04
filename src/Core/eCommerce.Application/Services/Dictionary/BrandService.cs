using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class BrandService : BaseEntityService<Brand>, IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _repository;

        private readonly ICountryRepository _countryRepository;

        public BrandService(IMapper mapper, IBrandRepository repository, ICountryRepository countryRepository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
            _countryRepository = countryRepository;

        }



        public IEnumerable<DropDownDto> GetList()
        {
            return GetAll().Select(x => new DropDownDto
            {
                Value = x.Id,
                DisplayText = x.Name
            }).ToList();

        }
        public IEnumerable<DropDownDto> GetListCountryId(int countryId)
        {
            return GetAll().Where(x => x.CountryId == countryId).Select(x => new DropDownDto
            {
                Value = x.Id,
                DisplayText = x.Name
            }).ToList();

        }
        public IEnumerable<DropDownDto> GetPageableList(DropdownRequest request)
        {
            var query = GetAll();

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
        public IEnumerable<DropDownDto> GetPageableListByCountryId(DropdownRequest request)
        {
            var query = GetAll();

            query = query.Where(x => x.CountryId == request.DependentColumnId);

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

        public IEnumerable<BrandDTO> GetTableByCountryId(int countryId)
        {
            return _repository.GetAll().Where(x => x.CountryId == countryId).Select(entity => new BrandDTO
            {
                Id = entity.Id,
                CountryId = entity.CountryId,
                Name = entity.Name,


            }).ToList();

        }
        public IEnumerable<BrandTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()
                        join b in _countryRepository.GetAll() on o.CountryId equals b.Id
                        select new BrandTableResponse
                        {
                            Id = o.Id,
                            CountryId = o.CountryId,
                            Name = o.Name,
                            CountryName = b.Name,

                        };

            return query;

        }
        public BrandUpdateRequest GetForUpdateById(int id)
        {
            var entity = Get(id);
            var model = _mapper.Map<BrandUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(BrandUpdateRequest model)
        {
            var entity = _mapper.Map<Brand>(model);

            await UpdateAsync(entity);


        }
        public void DeleteById(int id)
        {
            Brand entity = new Brand { Id = id };

            Delete(entity);
        }
        public async Task<BrandDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<BrandDTO>(entity);
        }

    }

}
