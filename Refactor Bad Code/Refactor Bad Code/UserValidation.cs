namespace Refactor_Bad_Code
{
    public class UserValidation
    {
        public string? CheckRegisterValidation(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name is required.";

            return CheckEmailValidation(email);
        }

        public string? CheckEmailValidation(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return "Email is required.";

            if (!email.Contains("@"))
                return "Email is invalid.";

            return null;
        }
    }
}
