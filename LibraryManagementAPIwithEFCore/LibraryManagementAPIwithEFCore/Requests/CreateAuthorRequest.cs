using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAPIwithEFCore.Requests
{
    public class CreateAuthorRequest
    {
        [Required, StringLength(50)]
        public string? Name { get; set; }
        [Required]        
        public DateTime DateOfBirth { get; set; }
    }
}
