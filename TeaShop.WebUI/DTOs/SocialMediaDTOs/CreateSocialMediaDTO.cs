namespace TeaShop.WebUI.DTOs.SocialMediaDTOs
{
	public class CreateSocialMediaDTO
	{
		public string? ImageURL { get; set; }
		public string? URL { get; set; }
		public bool IsHome { get; set; }
		public bool SocialMediaStatus { get; set; }
	}
}