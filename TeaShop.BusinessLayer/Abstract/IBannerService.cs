using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface IBannerService : IGenericService<Banner>
    {
        void TChangeBannerStatus(int id);
        void TChangeHomeStatus(int id);
        List<Banner> TGetLast3Banners();
    }
}