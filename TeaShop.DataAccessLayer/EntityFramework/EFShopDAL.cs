using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFShopDAL : GenericRepository<Shop>, IShopDAL
    {
        public EFShopDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeHomeStatus(int id)
        {
            var context = new TeaContext();
            var shop = context.Shops.Where(x => x.ShopID == id).FirstOrDefault();
            if (shop.IsHome == true)
            {
                shop.IsHome = false;
            }
            else
            {
                shop.IsHome = true;
            }
            context.Update(shop);
            context.SaveChanges();
        }

        public void ChangeShopStatus(int id)
        {
            var context = new TeaContext();
            var shop = context.Shops.Where(x => x.ShopID == id).FirstOrDefault();
            if (shop.ShopStatus == true)
            {
                shop.ShopStatus = false;
            }
            else
            {
                shop.ShopStatus = true;
            }
            context.Update(shop);
            context.SaveChanges();
        }

        public List<Shop> GetActiveShops()
        {
            var context = new TeaContext();
            var values = context.Shops.Where(x => x.ShopStatus == true).ToList();
            return values;
        }

        public List<Shop> GetLast3Shops()
        {
            var context = new TeaContext();
            var shopCount = context.Shops.Where(x => x.ShopStatus == true && x.IsHome == true).Count();
            var values = context.Shops.Where(x => x.ShopStatus == true && x.IsHome == true).ToList();
            if (shopCount <= 3)
            {
                values = context.Shops.Where(x => x.ShopStatus == true && x.IsHome == true).OrderByDescending(x => x.ShopID).ToList();
            }
            else
            {
                values = context.Shops.Where(x => x.ShopStatus == true && x.IsHome == true).OrderByDescending(x => x.ShopID).Take(3).ToList();
            }
            return values;
        }
    }
}