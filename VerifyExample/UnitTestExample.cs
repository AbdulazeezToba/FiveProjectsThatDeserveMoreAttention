using System;
using FluentAssertions;
using Xunit;

namespace VerifyExample
{
    public class UnitTestExample
    {
        [Fact]
        public void GetById_ShouldReturnTheRightPersonById_WhenThePersonExists()
        {
            // Arrange
            var sut = new PeopleRepository();

            // Act
            var person = sut.GetById(Guid.Parse("ebced679-45d3-4653-8791-3d969c4a986c"));

            // Assert
            person.Id.Should().Be("ebced679-45d3-4653-8791-3d969c4a986c");
            person.GivenNames.Should().Be("Emmy");
            person.FamilyName.Should().Be("Annachiara");
            person.Description.Should().Be("Emmy Annachiara (ebced679-45d3-4653-8791-3d969c4a986c)");
            person.DateOfBirth.Should().Be(new(2000, 1, 2, 3, 0, 0));
            person.Address.Street.Should().Be("924 Jehovah Drive");
            person.Address.City.Should().Be("Strasburg");
            person.Address.State.Should().Be("Virginia");
        }
    }
}
