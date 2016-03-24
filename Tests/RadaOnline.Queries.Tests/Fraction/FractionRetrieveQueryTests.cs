namespace RadaOnline.Queries.Tests.Fraction
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Fraction;

    [TestClass]
    public class FractionRetrieveQueryTests
    {
        [TestMethod]
        public void Execute_Should_Call_FractionRepository_Retrieve()
        {
            //Arrange
            var repositoryMock = new Mock<IFractionRepository>();
            var query = new FractionRetrieveQuery(repositoryMock.Object);
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            //Act
            query.Execute(id);

            //Assert
            repositoryMock.Verify(x => x.Retrieve(id), Times.Once);
        }
    }
}
