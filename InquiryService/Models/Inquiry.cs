namespace InquiryService.Models
{
    public class Inquiry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PropertyID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
