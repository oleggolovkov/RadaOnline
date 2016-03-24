namespace RadaOnline.Queries.Tests.Council
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Council;

    [TestClass]
    public class CouncilOverviewQueryTests
    {
        [TestMethod]
        public void Execute_Should_Call_CouncilRepository_Overview()
        {
            //Arrange
            var repositoryMock = new Mock<ICouncilRepository>();
            var query = new CouncilOverviewQuery(repositoryMock.Object);
            var fixture = new Fixture();
            var name = fixture.Create<string>();
            var take = fixture.Create<int>();
            var skip = fixture.Create<int>();

            //Act
            query.Execute(name, take, skip);

            //Assert
            repositoryMock.Verify(x => x.Overview(name, take, skip), Times.Once);
        }
    }
}
