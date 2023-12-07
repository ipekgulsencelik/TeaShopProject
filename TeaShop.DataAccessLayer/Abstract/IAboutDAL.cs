using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface IAboutDAL : IGenericDAL<About>
    {
        void ChangeAboutStatus(int id);
        void ChangeHomeStatus(int id);
        void ChangeFooterStatus(int id);
        List<About> GetLast3Abouts();
        List<About> GetActiveAbouts();
        About GetAboutByFooterStatus();
    }
}