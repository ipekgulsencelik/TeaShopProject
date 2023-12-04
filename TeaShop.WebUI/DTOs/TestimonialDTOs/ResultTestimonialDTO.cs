namespace TeaShop.WebUI.DTOs.TestimonialDTOs
{
    public class ResultTestimonialDTO
    {
        public int TestimonialID { get; set; }
        public string? TestimonialName { get; set; }
        public string? TestimonialComment { get; set; }
        public string? TestimonialImageURL { get; set; }
        public string? TestimonialTitle { get; set; }
        public bool IsHome { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}