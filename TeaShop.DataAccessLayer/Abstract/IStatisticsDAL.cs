namespace TeaShop.DataAccessLayer.Abstract
{
    public interface IStatisticsDAL
    {
        int DrinkCount();
        decimal AverageDrinkPrice();
        string LastDrinkName();
        string MaxDrinkPrice();
        int TestimonialCount();
        int QuestionCount();
        int MessageCount();
        int SubscriberCount();
    }
}