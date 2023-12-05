namespace TeaShop.BusinessLayer.Abstract
{
    public interface IStatisticsService
    {
        int TDrinkCount();
        decimal TAverageDrinkPrice();
        string TLastDrinkName();
        string TMaxDrinkPrice();
    }
}