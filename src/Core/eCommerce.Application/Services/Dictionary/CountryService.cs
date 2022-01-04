using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class CountryService : BaseEntityService<Country>, ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _repository;


        public CountryService(IMapper mapper, ICountryRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;

        }



        public IEnumerable<CountryTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()

                        select new CountryTableResponse
                        {
                            Id = o.Id,
                            Name = o.Name,

                        };

            return query;

        }
        public CountryUpdateRequest GetForUpdateById(int id)
        {
            var entity = Get(id);
            var model = _mapper.Map<CountryUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(CountryUpdateRequest model)
        {
            var entity = _mapper.Map<Country>(model);

            await UpdateAsync(entity);


        }
        public void DeleteById(int id)
        {
            Country entity = new Country { Id = id };

            Delete(entity);
        }
        public async Task<CountryDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<CountryDTO>(entity);
        }

    }

}
