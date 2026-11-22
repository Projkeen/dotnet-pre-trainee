using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.Requests
{
    public class UpdateAuthorRequest
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
