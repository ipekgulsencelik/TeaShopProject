using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.DrinkDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DrinksController : ControllerBase
	{
		private readonly IDrinkService _drinkService;

		public DrinksController(IDrinkService drinkService)
		{
			_drinkService = drinkService;
		}

		[HttpGet]
		public IActionResult DrinkList()
		{
			var values = _drinkService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateDrink(CreateDrinkDTO createDrinkDTO)
		{
			Drink drink = new Drink()
			{
				DrinkImageURL = createDrinkDTO.DrinkImageURL,
				DrinkName = createDrinkDTO.DrinkName,
				DrinkPrice = createDrinkDTO.DrinkPrice,
				IsHome = createDrinkDTO.IsHome,
				DrinkStatus = createDrinkDTO.DrinkStatus
			};
			_drinkService.TInsert(drink);
			return Ok("İçeceğiniz Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteDrink(int id)
		{
			var values = _drinkService.TGetByID(id);
			_drinkService.TDelete(values);
			return Ok("İçecek Başarılı Bir Şekilde Silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetDrink(int id)
		{
			var values = _drinkService.TGetByID(id);
			return Ok(values);
		}

		[HttpPut]
		public IActionResult UpdateDrink(UpdateDrinkDTO updateDrinkDTO)
		{
			Drink drink = new Drink()
			{
				DrinkImageURL = updateDrinkDTO.DrinkImageURL,
				DrinkName = updateDrinkDTO.DrinkName,
				DrinkPrice = updateDrinkDTO.DrinkPrice,
				IsHome = updateDrinkDTO.IsHome,
				DrinkStatus = updateDrinkDTO.DrinkStatus,
				DrinkID = updateDrinkDTO.DrinkID
			};
			_drinkService.TUpdate(drink);
			return Ok("İçeceğiniz Güncellendi");
		}

		[HttpGet("GetLast6Drinks")]
		public IActionResult GetLast6Drinks()
		{
			var values = _drinkService.TGetLast6Drinks();
			return Ok(values);
		}

		[HttpGet("GetActiveDrinks")]
		public IActionResult GetActiveDrinks()
		{
			var values = _drinkService.TGetActiveDrinks();
			return Ok(values);
		}

		[HttpGet("ChangeDrinkStatus/{id}")]
		public IActionResult ChangeDrinkStatus(int id)
		{
			_drinkService.TChangeDrinkStatus(id);
			return Ok("İçeceğinizin Durum Değeri Değiştirildi");
		}

		[HttpGet("ChangeHomeStatus/{id}")]
		public IActionResult ChangeHomeStatus(int id)
		{
			_drinkService.TChangeHomeStatus(id);
			return Ok("İçeceğinizin Ana Sayfa Görünürlüğü Değiştirildi");
		}
	}
}