using Xunit;
using System.Linq;
using Business.Blog;
using Service.Caching;

namespace Tests
{
    /// <summary>
    /// CachingMethodName_Should_ExpectedBehavior_When_StateUnderTest
    /// </summary>
    public class CachingTests : IClassFixture<Startup>
    {
        private readonly IBlogBusiness _blogBusiness;

        public CachingTests(IBlogBusiness blogBusiness, ICacheService cacheService)
        {
            _blogBusiness = blogBusiness;
        }

        [Fact]
        public void RefreshCache_Should_NotCallDatabaseTwice_WhenCacheNotRefreshed()
        {
            //arrange

            //act

            //first retrieve from db and cache blogs
            var retrievedFromDb = _blogBusiness.GetAll();

            var retrievedFromCache = _blogBusiness.GetAll();

            //assert
            Assert.True(retrievedFromCache.Count() == retrievedFromDb.Count());
        }
    }
}
