using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pokedex.BLL.Contracts;
using Pokedex.BLL.Implementations;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Tests
{
    public class SpeciesCreateServiceTests
    {
        [Test]
        public async Task InsertAsync_ValidationSuccess_CreatesSpecies()
        {
            // Arrange
            var fixture = new Fixture();
            var stats = fixture.CreateMany<int>(6).ToList();
            var species = fixture
                .Build<SpeciesUpdateModel>()
                .With(x => x.BaseStats, stats)
                .Create();
            var expected = new Species();

            var moveGetService = new Mock<IMoveGetService>();
            moveGetService.Setup(x => x.ValidateAsync(species));

            var speciesDataAccess = new Mock<ISpeciesDataAccess>();
            speciesDataAccess.Setup(x => x.InsertAsync(species)).ReturnsAsync(expected);

            var speciesCreateService = new SpeciesCreateService(speciesDataAccess.Object, moveGetService.Object);
            
            // Act
            var result = await speciesCreateService.InsertAsync(species);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}