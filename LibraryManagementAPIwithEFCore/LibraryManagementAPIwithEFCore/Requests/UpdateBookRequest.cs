using System.ComponentModel.DataAnnotations;

namespace LibraryManagementAPIwithEFCore.Requests
{
    public class UpdateBookRequest
    {
        [Required, StringLength(100)]
        public string? Title { get; set; }
        [Range(1, 2222, ErrorMessage = "Published year must be from 1 to 2222")]
        public int PublishedYear { get; set; }
        [Range(1, 9999)]
        public int AuthorId { get; set; }
    }
}
