namespace LibraryManagementAPIwithEFCore.Tests
{
    public class BookValidator
    {
        public int MaxTitleLength = 100;
        public int MinTitleLength = 1;
        public int MinPublishedYear = 1;
        public int MaxPublishedYear = 2222;
        public bool ValidateTitle(string title)
        {
            if(!string.IsNullOrWhiteSpace(title) && title.Length <= MaxTitleLength)
            {
                return true;
            }
            else { return false; }
        }

        public bool ValidateTitle(int length)
        {
            if ( length <= MaxTitleLength)
            {
                return true;
            }
            else { return false; }
        }

        public bool ValidatePublishedYear(int year)
        {
            if (year >= MinPublishedYear && year <= MaxPublishedYear)
            {
                return true;
            }
            else { return false; }
        }
    }
}
