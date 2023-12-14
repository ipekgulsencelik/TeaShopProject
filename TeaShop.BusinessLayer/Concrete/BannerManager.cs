using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class BannerManager : IBannerService
    {
        private readonly IBannerDAL _bannerDAL;

        public BannerManager(IBannerDAL bannerDAL)
        {
            _bannerDAL = bannerDAL;
        }

        public void TChangeBannerStatus(int id)
        {
            _bannerDAL.ChangeBannerStatus(id);
        }

        public void TChangeHomeStatus(int id)
        {
            _bannerDAL.ChangeHomeStatus(id);
        }

        public void TDelete(Banner entity)
        {
            _bannerDAL?.Delete(entity);
        }

        public List<Banner> TGetLast3Banners()
        {
            return _bannerDAL.GetLast3Banners();
        }

        public Banner TGetByID(int id)
        {
            return _bannerDAL.GetByID(id);
        }

        public List<Banner> TGetListAll()
        {
            return _bannerDAL.GetListAll();
        }

        public void TInsert(Banner entity)
        {
            _bannerDAL.Insert(entity);
        }

        public void TUpdate(Banner entity)
        {
            _bannerDAL.Update(entity);
        }
    }
}
