using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFStatisticsDAL : IStatisticsDAL
    {
        private readonly TeaContext _context;

        public EFStatisticsDAL(TeaContext context)
        {
            _context = context;
        }

        public decimal AverageDrinkPrice()
        {
            decimal value = _context.Drinks.Average(x => x.DrinkPrice);
            return value;
        }

        public int DrinkCount()
        {
            int value = _context.Drinks.Count();
            return value;
        }

        public string LastDrinkName()
        {
            string value = _context.Drinks.OrderByDescending(x => x.DrinkID).Select(x => x.DrinkName).Take(1).FirstOrDefault();
            return value;
        }

        public string MaxDrinkPrice()
        {
            decimal price = _context.Drinks.Max(x => x.DrinkPrice);
            string value = _context.Drinks.Where(x => x.DrinkPrice == price).Select(x => x.DrinkName).FirstOrDefault();
            return value;
        }
    }
}
