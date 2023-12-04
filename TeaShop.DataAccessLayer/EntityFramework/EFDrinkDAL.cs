using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
	public class EFDrinkDAL : GenericRepository<Drink>, IDrinkDAL
	{
		public EFDrinkDAL(TeaContext context) : base(context)
		{
		}

		public void ChangeDrinkStatus(int id)
		{
			var context = new TeaContext();
			var drink = context.Drinks.Where(x => x.DrinkID == id).FirstOrDefault();
			if (drink.DrinkStatus == true)
			{
				drink.DrinkStatus = false;
			}
			else
			{
				drink.DrinkStatus = true;
			}
			context.Update(drink);
			context.SaveChanges();
		}

		public void ChangeHomeStatus(int id)
		{
			var context = new TeaContext();
			var drink = context.Drinks.Where(x => x.DrinkID == id).FirstOrDefault();
			if (drink.IsHome == true)
			{
				drink.IsHome = false;
			}
			else
			{
				drink.IsHome = true;
			}
			context.Update(drink);
			context.SaveChanges();
		}

		public List<Drink> GetActiveDrinks()
		{
			var context = new TeaContext();
			var values = context.Drinks.Where(x => x.DrinkStatus == true).ToList();
			return values;
		}

		public List<Drink> GetLast6Drinks()
		{
			var context = new TeaContext();
			var drinkCount = context.Drinks.Where(x => x.DrinkStatus == true && x.IsHome == true).Count();
			var values = context.Drinks.Where(x => x.DrinkStatus == true && x.IsHome == true).ToList();
			if (drinkCount <= 6)
			{
				values = context.Drinks.Where(x => x.DrinkStatus == true && x.IsHome == true).OrderByDescending(x => x.DrinkID).ToList();
			}
			else
			{
				values = context.Drinks.Where(x => x.DrinkStatus == true && x.IsHome == true).OrderByDescending(x => x.DrinkID).Take(6).ToList();
			}
			return values;
		}
	}
}