namespace RadaOnline.Queries.Tests.Councilman
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Councilman;

    [TestClass]
    public class CouncilmanOverviewQueryTests
    {
        [TestMethod]
        public void Execute_Should_Call_CouncilmanRepository_Overview()
        {
            //Arrange
            var repositoryMock = new Mock<ICouncilmanRepository>();
            var query = new CouncilmanOverviewQuery(repositoryMock.Object);
            var fixture = new Fixture();
            var councilId = fixture.Create<int?>();
            var fractionId = fixture.Create<int?>();
            var name = fixture.Create<string>();
            var take = fixture.Create<int>();
            var skip = fixture.Create<int>();

            //Act
            query.Execute(councilId, fractionId, name, take, skip);

            //Assert
            repositoryMock.Verify(x => x.Overview(councilId, fractionId, name, take, skip), Times.Once);
        }
    }
}
