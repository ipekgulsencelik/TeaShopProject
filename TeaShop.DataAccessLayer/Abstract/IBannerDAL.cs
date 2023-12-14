using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface IBannerDAL : IGenericDAL<Banner>
    {
        void ChangeBannerStatus(int id);
        void ChangeHomeStatus(int id);
        List<Banner> GetLast3Banners();
    }
}