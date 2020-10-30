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
        public readonly ISudokuService _sut;
        public readonly Fixture _fixture;
        public SudokuServiceTests() 
        {
            _sudokuValidatorMock = new Mock<ISudokuValidator>();
            _sut = new SudokuService(_sudokuValidatorMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public void Solve_ShoudlReturnFailedResult_WhenValidatorReturnsError()
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
    }
}
