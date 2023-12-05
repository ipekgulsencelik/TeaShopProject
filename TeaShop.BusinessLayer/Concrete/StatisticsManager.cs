using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;

namespace TeaShop.BusinessLayer.Concrete
{
    public class StatisticsManager : IStatisticsService
    {
        private readonly IStatisticsDAL _statisticsDAL;

        public StatisticsManager(IStatisticsDAL statisticsDAL)
        {
            _statisticsDAL = statisticsDAL;
        }

        public decimal TAverageDrinkPrice()
        {
            return _statisticsDAL.AverageDrinkPrice();
        }

        public int TDrinkCount()
        {
            return _statisticsDAL.DrinkCount();
        }

        public string TLastDrinkName()
        {
            return _statisticsDAL.LastDrinkName();
        }

        public string TMaxDrinkPrice()
        {
            return _statisticsDAL.MaxDrinkPrice();
        }
    }
}