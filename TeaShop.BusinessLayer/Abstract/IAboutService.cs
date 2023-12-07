using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        void TChangeAboutStatus(int id);
        void TChangeHomeStatus(int id);
        void TChangeFooterStatus(int id);
        List<About> TGetLast3Abouts();
        List<About> TGetActiveAbouts();
		About TGetAboutByFooterStatus();
	}
}