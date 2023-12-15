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

        public int TMessageCount()
        {
            return _statisticsDAL.MessageCount();
        }

        public int TQuestionCount()
        {
            return _statisticsDAL.QuestionCount();
        }

        public int TSubscriberCount()
        {
            return _statisticsDAL.SubscriberCount();
        }

        public int TTestimonialCount()
        {
            return _statisticsDAL.TestimonialCount();
        }
    }
}