using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class ProductService : BaseEntityService<Product>, IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        private readonly IBrandRepository _brandRepository;
        private readonly ISubCategoryTranslationRepository _subCategoryTranslationRepository;
        private readonly IProductTranslationRepository _productTranslationRepository;

        public ProductService(IMapper mapper, IProductRepository repository, IBrandRepository brandRepository, ISubCategoryTranslationRepository subCategoryTranslationRepository, IProductTranslationRepository productTranslationRepository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
            _brandRepository = brandRepository;
            _subCategoryTranslationRepository = subCategoryTranslationRepository;
            _productTranslationRepository = productTranslationRepository;

        }



        public IEnumerable<ProductTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()
                        join bf in _brandRepository.GetAll() on o.BrendId equals bf.Id into bs
                        from b in bs.DefaultIfEmpty()
                        join c in _subCategoryTranslationRepository.GetAll() on o.SubCategoryId equals c.Id
                        select new ProductTableResponse
                        {
                            Id = o.Id,
                            BrendId = o.BrendId,
                            SubCategoryId = o.SubCategoryId,
                            Name = o.Name,
                            Description = o.Description,
                            Code = o.Code,
                            Price = o.Price,
                            Count = o.Count,
                            InsertDate = o.InsertDate,
                            BrendName = b.Name,
                            SubCategoryName = c.Name,

                        };

            return query;

        }
        public ProductUpdateRequest GetForUpdateById(int id)
        {
            var entity = IncludeMany(x => x.Id == id, x => x.ProductTranslations).SingleOrDefault();
            var model = _mapper.Map<ProductUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(ProductUpdateRequest model)
        {
            var entity = _mapper.Map<Product>(model);

            await UpdateAsync(entity);


            foreach (var id in model.DeletedProductTranslations)
            {
                var deleted = new ProductTranslation { Id = id };

                _productTranslationRepository.Delete(deleted);
            }
        }
        public void DeleteById(int id)
        {
            Product entity = new Product { Id = id };

            Delete(entity);
        }
        public async Task<ProductDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<ProductDTO>(entity);
        }

    }

}
