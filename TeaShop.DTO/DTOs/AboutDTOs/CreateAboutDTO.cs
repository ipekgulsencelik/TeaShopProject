namespace TeaShop.DTO.DTOs.AboutDTOs
{
    public class CreateAboutDTO
    {
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string? AboutImageURL { get; set; }
        public bool IsHome { get; set; }
        public bool IsFooter { get; set; }
        public bool AboutStatus { get; set; }
    }
}