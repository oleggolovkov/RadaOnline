namespace RadaOnline.Queries.Tests.Council
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Council;

    [TestClass]
    public class CouncilRetrieveQueryTests
    {
        [TestMethod]
        public void Execute_Should_Call_CouncilRepository_Retrieve()
        {
            //Arrange
            var repositoryMock = new Mock<ICouncilRepository>();
            var query = new CouncilRetrieveQuery(repositoryMock.Object);
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            //Act
            query.Execute(id);

            //Assert
            repositoryMock.Verify(x => x.Retrieve(id), Times.Once);
        }
    }
}
