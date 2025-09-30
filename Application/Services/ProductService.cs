using Application.Dtos.ProductsDtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable <ProductDto >> (products);
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map <ProductDto ?>(product);
        }

        public async Task<ProductDto> AddProductAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto dto)
        {
            //var product = await _repository.GetByIdAsync(id);
            //if (product != null)
            //{
            //    product = _mapper.Map<Product>(dto);
            //    _repository.Update(product);
            //    await _repository.SaveChangesAsync();
            //}
            var existingProduct = await _repository.GetByIdAsync(id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            // Update fields
            existingProduct.ProductName = dto.ProductName;

            _repository.Update(existingProduct);
            await _repository.SaveChangesAsync();

            // Return updated value
            return _mapper.Map<ProductDto>(existingProduct);

        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product != null)
            {
                _repository.Delete(product);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
