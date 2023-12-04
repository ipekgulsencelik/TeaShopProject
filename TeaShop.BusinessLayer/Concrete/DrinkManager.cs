using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
	public class DrinkManager : IDrinkService
	{
		private readonly IDrinkDAL _drinkDAL;

		public DrinkManager(IDrinkDAL drinkDAL)
		{
			_drinkDAL = drinkDAL;
		}

		public void TChangeDrinkStatus(int id)
		{
			_drinkDAL.ChangeDrinkStatus(id);
		}

		public void TChangeHomeStatus(int id)
		{
			_drinkDAL.ChangeHomeStatus(id);
		}

		public void TDelete(Drink entity)
		{
			_drinkDAL.Delete(entity);
		}

		public List<Drink> TGetActiveDrinks()
		{
			return _drinkDAL.GetActiveDrinks();
		}

		public Drink TGetByID(int id)
		{
			return _drinkDAL.GetByID(id);
		}

		public List<Drink> TGetLast6Drinks()
		{
			return _drinkDAL.GetLast6Drinks();
		}

		public List<Drink> TGetListAll()
		{
			return _drinkDAL.GetListAll();
		}

		public void TInsert(Drink entity)
		{
			_drinkDAL.Insert(entity);
		}

		public void TUpdate(Drink entity)
		{
			_drinkDAL.Update(entity);
		}
	}
}