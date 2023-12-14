using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFBannerDAL : GenericRepository<Banner>, IBannerDAL
    {
        public EFBannerDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeBannerStatus(int id)
        {
            var context = new TeaContext();
            var banner = context.Banners.Where(x => x.BannerID == id).FirstOrDefault();
            if (banner.BannerStatus == true)
            {
                banner.BannerStatus = false;
            }
            else
            {
                banner.BannerStatus = true;
            }
            context.Update(banner);
            context.SaveChanges();
        }

        public void ChangeHomeStatus(int id)
        {
            var context = new TeaContext();
            var banner = context.Banners.Where(x => x.BannerID == id).FirstOrDefault();
            if (banner.IsHome == true)
            {
                banner.IsHome = false;
            }
            else
            {
                banner.IsHome = true;
            }
            context.Update(banner);
            context.SaveChanges();
        }

        public List<Banner> GetLast3Banners()
        {
            var context = new TeaContext();
            var bannerCount = context.Banners.Where(x => x.BannerStatus == true && x.IsHome == true).Count();
            var values = context.Banners.Where(x => x.BannerStatus == true && x.IsHome == true).ToList();
            if (bannerCount <= 3)
            {
                values = context.Banners.Where(x => x.BannerStatus == true && x.IsHome == true).OrderByDescending(x => x.BannerID).ToList();
            }
            else
            {
                values = context.Banners.Where(x => x.BannerStatus == true && x.IsHome == true).OrderByDescending(x => x.BannerID).Take(3).ToList();
            }
            return values;
        }
    }
}