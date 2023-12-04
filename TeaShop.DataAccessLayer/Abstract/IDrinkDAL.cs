using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
	public interface IDrinkDAL : IGenericDAL<Drink>
	{
		void ChangeDrinkStatus(int id);
		List<Drink> GetLast6Drinks();
		List<Drink> GetActiveDrinks();
		void ChangeHomeStatus(int id);
	}
}