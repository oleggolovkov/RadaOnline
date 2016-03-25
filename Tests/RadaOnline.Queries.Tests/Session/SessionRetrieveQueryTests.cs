namespace RadaOnline.Queries.Tests.Session
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Session;

    [TestClass]
    public class SessionRetrieveQueryTests
    {
        [TestMethod]
        public void Execute_Should_Call_SessionRepository_Retrieve()
        {
            //Arrange
            var repositoryMock = new Mock<ISessionRepository>();
            var query = new SessionRetrieveQuery(repositoryMock.Object);
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            //Act
            query.Execute(id);

            //Assert
            repositoryMock.Verify(x => x.Retrieve(id), Times.Once);
        }
    }
}
