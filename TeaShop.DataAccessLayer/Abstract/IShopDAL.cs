using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface IShopDAL : IGenericDAL<Shop>
    {
        void ChangeShopStatus(int id);
        void ChangeHomeStatus(int id);
        List<Shop> GetLast3Shops();
        List<Shop> GetActiveShops();
    }
}