namespace AspNet.Essentials.Workshop.Models
{
    public class Results
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int TotalResults { get; set; }
        public Beer[] Data { get; set; }
        public string Status { get; set; }
    }
}