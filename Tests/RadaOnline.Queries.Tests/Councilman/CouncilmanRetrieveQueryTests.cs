namespace RadaOnline.Queries.Tests.Councilman
{
    using Database.Repositories.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ploeh.AutoFixture;
    using RadaOnline.Queries.Councilman;

    [TestClass]
    public class CouncilmanRetrieveQueryTests
    {
        [TestMethod]
        public void Execute_Should_Call_CouncilmanRepository_Retrieve()
        {
            //Arrange
            var repositoryMock = new Mock<ICouncilmanRepository>();
            var query = new CouncilmanRetrieveQuery(repositoryMock.Object);
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            //Act
            query.Execute(id);

            //Assert
            repositoryMock.Verify(x => x.Retrieve(id), Times.Never);
        }
    }
}
