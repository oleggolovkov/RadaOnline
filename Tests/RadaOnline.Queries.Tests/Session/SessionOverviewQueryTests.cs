namespace RadaOnline.Queries.Tests.Session
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Session;

    [TestClass]
    public class SessionOverviewQueryTests
    {
        [TestMethod]
        public void Execute_Should_Call_SessionRepository_Overview()
        {
            //Arrange
            var repositoryMock = new Mock<ISessionRepository>();
            var query = new SessionOverviewQuery(repositoryMock.Object);
            var fixture = new Fixture();
            var councilId = fixture.Create<int?>();
            var take = fixture.Create<int>();
            var skip = fixture.Create<int>();

            //Act
            query.Execute(councilId, take, skip);

            //Assert
            repositoryMock.Verify(x => x.Overview(councilId, take, skip), Times.Once);
        }
    }
}
