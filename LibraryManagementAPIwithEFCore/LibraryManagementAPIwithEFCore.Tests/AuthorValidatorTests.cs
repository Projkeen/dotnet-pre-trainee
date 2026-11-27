namespace LibraryManagementAPIwithEFCore.Tests
{
    public class AuthorValidatorTests
    {
        [Theory]
        [InlineData("George Orwell")]
        [InlineData("J.R.R. Tolkien")]
        [InlineData("Robert C. Martin")]        
        public void ValidateName_ReturnsTrue_WhenNameIsValid(string name)
        {
            var validator = new AuthorValidator();

            var result = validator.ValidateName(name);

            Assert.True(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]        
        public void ValidateName_ReturnsFalse_WhenNameIsEmpty(string? name)
        {
            var validator = new AuthorValidator();

            var result = validator.ValidateName(name);

            Assert.False(result);
        }

        [Theory]        
        [InlineData("   ")]
        [InlineData(" ")]
        public void ValidateName_ReturnsFalse_WhenNameIsWhitespace(string? name)
        {
            var validator = new AuthorValidator();

            var result = validator.ValidateName(name);

            Assert.False(result);
        }

        [Fact]
        public void ValidateDateOfBirth_ReturnsTrue_WhenDateIsInThePast()
        {
            var validator = new AuthorValidator();

            var dateOfBirth = new DateTime(1952, 12, 05);

            var result = validator.ValidateDateOfBirth(dateOfBirth, DateTime.Now);

            Assert.True(result);
        }

        [Fact]
        public void ValidateDateOfBirth_ReturnsTrue_WhenDateIsToday()
        {
            var validator = new AuthorValidator();

            var dateOfBirth = DateTime.Now;

            var result = validator.ValidateDateOfBirth(dateOfBirth, DateTime.Now);

            Assert.True(result);
        }

        [Fact]
        public void ValidateDateOfBirth_ReturnsFalse_WhenDateIsInTheFuture()
        {
            var validator = new AuthorValidator();

            var dateOfBirth = DateTime.Now.AddDays(1);

            var result = validator.ValidateDateOfBirth(dateOfBirth, DateTime.Now);

            Assert.False(result);
        }
    }
}
