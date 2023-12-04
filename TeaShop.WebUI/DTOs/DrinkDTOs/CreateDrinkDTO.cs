namespace TeaShop.WebUI.DTOs.DrinkDTOs
{
	public class CreateDrinkDTO
	{
		public string DrinkName { get; set; }
		public decimal DrinkPrice { get; set; }
		public string? DrinkImageURL { get; set; }
		public bool IsHome { get; set; }
		public bool DrinkStatus { get; set; }
	}
}