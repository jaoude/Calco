using Calco.BLL.Models;
using Calco.BLL.Services;
using Calco.BLL.Services.Validator;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;
using static Calco.Common.Constants;
using AutoFixture;

namespace Calco.Tests.Bll.Services.Validator
{
    public class SudokuServiceTests
    {
        public readonly Mock<ISudokuValidator> _sudokuValidatorMock;
        public readonly Mock<ISudokuSolver> _sudokuSolverMock;
        public readonly ISudokuService _sut;
        public readonly Fixture _fixture;
        public SudokuServiceTests() 
        {
            _sudokuValidatorMock = new Mock<ISudokuValidator>();
            _sudokuSolverMock = new Mock<ISudokuSolver>();
            _sut = new SudokuService(_sudokuValidatorMock.Object, _sudokuSolverMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public void Solve_ShouldReturnFailedResult_WhenValidatorReturnsError()
        {
            // Arrange 
            var message = _fixture.Create<string>();
            _sudokuValidatorMock.Setup(x => x.Validate(It.IsAny<List<int?>>())).Returns(message);

            // Act
            var result = _sut.Solve(It.IsAny<List<int?>>());

            // Assert
            result.Message.Should().Be(message);
            result.Success.Should().BeFalse();
            result.Solution.Should().BeNull();
        }

        [Fact]
        public void Solve_ShouldMakeTheCorrectCalls_WhenCalled()
        {
            // Arrange 
            var message = _fixture.Create<string>();

            // Act
            var result = _sut.Solve(It.IsAny<List<int?>>());

            // Assert
            _sudokuValidatorMock.Verify(x => x.Validate(It.IsAny<List<int?>>()), Times.Once());
            _sudokuSolverMock.Verify(x => x.Solve(It.IsAny<List<int?>>()), Times.Once());
        }
    }
}
