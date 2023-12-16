﻿namespace TeaShop.WebUI.DTOs.SocialMediaDTOs
{
	public class UpdateSocialMediaDTO
	{
		public int SocialMediaID { get; set; }
		public string? ImageURL { get; set; }
		public string? URL { get; set; }
		public bool IsHome { get; set; }
		public bool SocialMediaStatus { get; set; }
	}
}