using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.Requests
{
    public class CreateAuthorRequest
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        [Required]        
        public DateTime DateOfBirth { get; set; }
    }
}
