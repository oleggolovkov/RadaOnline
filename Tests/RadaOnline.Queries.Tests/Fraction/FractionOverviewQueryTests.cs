namespace RadaOnline.Queries.Tests.Fraction
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    using RadaOnline.Database.Repositories.Interfaces;
    using RadaOnline.Queries.Fraction;

    [TestClass]
    public class FractionOverviewQueryTests
    {
        [TestMethod]
        public void Execute_Should_Call_FractionRepository_Overview()
        {
            //Arrange
            var repositoryMock = new Mock<IFractionRepository>();
            var query = new FractionOverviewQuery(repositoryMock.Object);
            var fixture = new Fixture();
            var councilId = fixture.Create<int?>();
            var name = fixture.Create<string>();
            var take = fixture.Create<int>();
            var skip = fixture.Create<int>();

            //Act
            query.Execute(councilId, name, take, skip);

            //Assert
            repositoryMock.Verify(x => x.Overview(councilId, name, take, skip), Times.Once);
        }
    }
}
