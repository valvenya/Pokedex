using System;
using System.Collections.Generic;
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
using Pokedex.Domain.Contracts;

namespace Pokedex.BLL.Tests
{
    public class MoveGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_MovesExist_DoesNothing()
        {
            // Arrange
            var fixture = new Fixture();
            var movesContainer = new Mock<IMovesContainer>();
            var moveIds = fixture.CreateMany<int>().ToList();
            movesContainer.Setup(m => m.MoveIds).Returns(moveIds);
            var moveDataAccess = new Mock<IMoveDataAccess>();
            var moves = moveIds.Select(id => new Domain.Move() {Id = id}).ToList();
            fixture.AddManyTo(moves);
            moveDataAccess.Setup(x => x.GetAsync()).ReturnsAsync(moves);
            var moveGetService = new MoveGetService(moveDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => moveGetService.ValidateAsync(movesContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_MovesNotExist_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var movesContainer = new Mock<IMovesContainer>();
            var moveIds = fixture.CreateMany<int>().ToList();
            movesContainer.Setup(m => m.MoveIds).Returns(moveIds);
            var moveDataAccess = new Mock<IMoveDataAccess>();
            moveDataAccess.Setup(x => x.GetAsync()).ReturnsAsync(new List<Move>());
            var moveGetService = new MoveGetService(moveDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => moveGetService.ValidateAsync(movesContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>("Moves not found");
        }

        [Test]
        public async Task GetAsync_ReturnsMove()
        {
            // Arrange
            var fixture = new Fixture();
            var moveIdentity = new Mock<IMoveIdentity>();
            var id = fixture.Create<int>();
            moveIdentity.Setup(x => x.Id).Returns(id);
            var expected = new Move() { Id = id };
            var moveDataAccess = new Mock<IMoveDataAccess>();
            moveDataAccess.Setup(x => x.GetAsync(moveIdentity.Object)).ReturnsAsync(expected);
            var moveGetService = new MoveGetService(moveDataAccess.Object);
            
            // Act
            var result = await moveGetService.GetAsync(moveIdentity.Object);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}