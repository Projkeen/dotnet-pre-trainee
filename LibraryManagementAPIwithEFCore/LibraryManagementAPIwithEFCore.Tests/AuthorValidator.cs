namespace LibraryManagementAPIwithEFCore.Tests
{
    public class AuthorValidator
    {
        public int MaxNameLength = 50;

        public bool ValidateName(string name)
        {
            if(!string.IsNullOrWhiteSpace(name) && name.Length <= MaxNameLength)
            {
                return true;
            }
            else { return false; }
        }        

        public bool ValidateDateOfBirth(DateTime dateOfBirth, DateTime now)
        {
            if (dateOfBirth <= now)
            {
                return true;
            }
            else { return false; }
        }
    }
}
