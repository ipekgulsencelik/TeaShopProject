using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class ShopManager : IShopService
    {
        private readonly IShopDAL _shopDAL;

        public ShopManager(IShopDAL shopDAL)
        {
            _shopDAL = shopDAL;
        }

        public void TChangeHomeStatus(int id)
        {
            _shopDAL.ChangeHomeStatus(id);
        }

        public void TChangeShopStatus(int id)
        {
            _shopDAL.ChangeShopStatus(id);
        }

        public void TDelete(Shop entity)
        {
            _shopDAL.Delete(entity);
        }

        public List<Shop> TGetActiveShops()
        {
            return _shopDAL.GetActiveShops();
        }

        public Shop TGetByID(int id)
        {
            return _shopDAL.GetByID(id);
        }

        public List<Shop> TGetLast3Shops()
        {
            return _shopDAL.GetLast3Shops();
        }

        public List<Shop> TGetListAll()
        {
            return _shopDAL.GetListAll();
        }

        public void TInsert(Shop entity)
        {
            _shopDAL.Insert(entity);
        }

        public void TUpdate(Shop entity)
        {
            _shopDAL.Update(entity);
        }
    }
}