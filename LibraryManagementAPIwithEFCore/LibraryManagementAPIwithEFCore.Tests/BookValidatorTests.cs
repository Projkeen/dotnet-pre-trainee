using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAPIwithEFCore.Tests
{
    public class BookValidatorTests
    {      
        [Theory]
        [InlineData("1984")]
        [InlineData("The Hobbit")]
        [InlineData("Clean Code")]
        public void ValidateTitle_ReturnsTrue_WhenTitleIsValid(string title)
        {
            var validator = new BookValidator();

            var result = validator.ValidateTitle(title);

            Assert.True(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]               
        public void ValidateTitle_ReturnsFalse_WhenTitleIsEmpty(string? title)
        {
            var validator = new BookValidator();

            var result = validator.ValidateTitle(title);

            Assert.False(result);
        }

        [Theory]        
        [InlineData("  ")]
        [InlineData("         ")]
        public void ValidateTitle_ReturnsFalse_WhenTitleIsWhitespace(string? title)
        {
            var validator = new BookValidator();

            var result = validator.ValidateTitle(title);

            Assert.False(result);
        }
        
        [Fact]
        public void ValidateTitle_ReturnsFalse_WhenTitleIsLongerThanMaximum()
        {
            var validator = new BookValidator();

            var charCount = validator.MaxTitleLength + 1;

            var result = validator.ValidateTitle(charCount);

            Assert.False(result);
        }

        [Theory]
        [InlineData(99)]
        [InlineData(100)]        
        public void ValidateTitle_ReturnsTrue_WhenTitleIsLessThanMaximum(int charCount)
        {
            var validator = new BookValidator();            

            var result = validator.ValidateTitle(charCount);

            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]          
        [InlineData(2008)]
        [InlineData(2222)]   
        public void ValidatePublishedYear_ReturnsTrue_WhenYearIsInAllowedRange(int year)
        {
            var validator = new BookValidator();

            var result = validator.ValidatePublishedYear(year);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]        
        [InlineData(2223)]
        public void ValidatePublishedYear_ReturnsFalse_WhenYearIsInNotAllowedRange(int year)
        {
            var validator = new BookValidator();

            var result = validator.ValidatePublishedYear(year);

            Assert.False(result);
        }
    }
}
