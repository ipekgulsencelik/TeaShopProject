namespace TeaShop.WebUI.DTOs.DrinkDTOs
{
	public class UpdateDrinkDTO
	{
		public int DrinkID { get; set; }
		public string DrinkName { get; set; }
		public decimal DrinkPrice { get; set; }
		public string? DrinkImageURL { get; set; }
		public bool IsHome { get; set; }
		public bool DrinkStatus { get; set; }
	}
}