using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
	public interface IDrinkService : IGenericService<Drink>
	{
		void TChangeDrinkStatus(int id);
		List<Drink> TGetLast6Drinks();
		List<Drink> TGetActiveDrinks();
		void TChangeHomeStatus(int id);
	}
}