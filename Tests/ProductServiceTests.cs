using Application.Dtos.ProductsDtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Mock<IProductRepository> _repoMock;
        private IMapper _mapper;
        private ProductService _service;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IProductRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>().ReverseMap();
                cfg.CreateMap<CreateProductDto, Product>();
                cfg.CreateMap<UpdateProductDto, Product>();
            });

            _mapper = config.CreateMapper();
            _service = new ProductService(_repoMock.Object, _mapper);
        }

        [Test]
        public async Task AddProductAsync_ShouldReturnProductDto()
        {
            var createDto = new CreateProductDto { ProductName = "Laptop" };
            _repoMock.Setup(r => r.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
            _repoMock.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            var result = await _service.AddProductAsync(createDto);

            Assert.IsNotNull(result);
            Assert.AreEqual("Laptop", result.ProductName);
            _repoMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
            _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllProductsAsync_ShouldReturnListOfProducts()
        {
            var entities = new List<Product>
            {
                new Product { ProductId = Guid.NewGuid(), ProductName = "Laptop" },
                new Product { ProductId = Guid.NewGuid(), ProductName = "Laptop" }
            };
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);

            var result = await _service.GetAllProductsAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.All(p => p.ProductName == "Laptop"));
        }

        [Test]
        public async Task GetProductByIdAsync_ShouldReturnProductDto()
        {
            var id = Guid.NewGuid();
            var entity = new Product { ProductId = id, ProductName = "Laptop" };
            _repoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(entity);

            var result = await _service.GetProductByIdAsync(id);

            Assert.IsNotNull(result);
            Assert.AreEqual("Laptop", result.ProductName);
        }

        [Test]
        public async Task UpdateProductAsync_ShouldReturnUpdatedProduct()
        {
            var id = Guid.NewGuid();
            var entity = new Product { ProductId = id, ProductName = "Old Laptop" };
            var updateDto = new UpdateProductDto { ProductName = "Laptop" };

            _repoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(entity);
            _repoMock.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            var updated = await _service.UpdateProductAsync(id, updateDto);

            Assert.IsNotNull(updated);
            Assert.AreEqual("Laptop", updated.ProductName);
            _repoMock.Verify(r => r.Update(entity), Times.Once);
            _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void UpdateProductAsync_InvalidId_ShouldThrowException()
        {
            var id = Guid.NewGuid();
            var updateDto = new UpdateProductDto { ProductName = "Laptop" };
            _repoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Product?)null);

            Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await _service.UpdateProductAsync(id, updateDto));
        }

        [Test]
        public async Task DeleteProductAsync_ShouldCallRepositoryDelete()
        {
            var id = Guid.NewGuid();
            var entity = new Product { ProductId = id, ProductName = "Laptop" };

            _repoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(entity);
            _repoMock.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            await _service.DeleteProductAsync(id);

            _repoMock.Verify(r => r.Delete(entity), Times.Once);
            _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
 