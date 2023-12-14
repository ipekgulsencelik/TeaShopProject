namespace TeaShop.WebUI.DTOs.BannerDTOs
{
    public class CreateBannerDTO
    {
        public string BannerTitle { get; set; }
        public string BannerSubTitle { get; set; }
        public string BannerImageURL { get; set; }
        public bool IsHome { get; set; }
        public bool BannerStatus { get; set; }
    }
}