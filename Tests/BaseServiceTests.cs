using AutoMapper;
using Infrastructure.Repositories;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public abstract class BaseServiceTests<TEntity, TDto, TRepository, TService>
        where TEntity : class, new()
        where TDto : class, new()
        where TRepository : class, IGenericRepository<TEntity>
    {
        protected Mock<TRepository> _repoMock;
        protected IMapper _mapper;
        protected TService _service;

        [SetUp]
        public void BaseSetup()
        {
            _repoMock = new Mock<TRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                ConfigureMapping(cfg);
            });

            _mapper = config.CreateMapper();

            _service = CreateService(_repoMock.Object, _mapper);
        }

        protected abstract void ConfigureMapping(IMapperConfigurationExpression cfg);
        protected abstract TService CreateService(TRepository repo, IMapper mapper);

        [Test]
        public async Task AddEntity_ShouldReturnDto_WhenEntityAdded()
        {
            var dto = new TDto();
            var entity = new TEntity();

            _repoMock.Setup(r => r.AddAsync(It.IsAny<TEntity>()))
                     .Returns(Task.CompletedTask);

            var addMethod = typeof(TService).GetMethod("AddAsync");
            var result = await (Task<TDto>)addMethod.Invoke(_service, new object[] { dto });

            Assert.IsNotNull(result);
            _repoMock.Verify(r => r.AddAsync(It.IsAny<TEntity>()), Times.Once);
        }

        [Test]
        public async Task GetAllEntities_ShouldReturnList_WhenEntitiesExist()
        {
            var entities = new List<TEntity> { new TEntity(), new TEntity() };
            _repoMock.Setup(r => r.GetAllAsync())
                     .ReturnsAsync(entities);

            var getAllMethod = typeof(TService).GetMethod("GetAllAsync");
            var result = await (Task<IEnumerable<TDto>>)getAllMethod.Invoke(_service, null);

            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}
