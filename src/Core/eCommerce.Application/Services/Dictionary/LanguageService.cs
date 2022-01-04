using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class LanguageService : BaseEntityService<Language>, ILanguageService
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _repository;


        public LanguageService(IMapper mapper, ILanguageRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;

        }



        public IEnumerable<LanguageTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()

                        select new LanguageTableResponse
                        {
                            Id = o.Id,
                            Name = o.Name,
                            Culture = o.Culture,

                        };

            return query;

        }
        public LanguageUpdateRequest GetForUpdateById(int id)
        {
            var entity = Get(id);
            var model = _mapper.Map<LanguageUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(LanguageUpdateRequest model)
        {
            var entity = _mapper.Map<Language>(model);

            await UpdateAsync(entity);


        }
        public void DeleteById(int id)
        {
            Language entity = new Language { Id = id };

            Delete(entity);
        }
        public async Task<LanguageDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<LanguageDTO>(entity);
        }

    }

}
