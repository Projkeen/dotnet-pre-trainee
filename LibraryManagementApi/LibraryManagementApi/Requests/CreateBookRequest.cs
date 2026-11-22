namespace LibraryManagementApi.Requests
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
    }
}
