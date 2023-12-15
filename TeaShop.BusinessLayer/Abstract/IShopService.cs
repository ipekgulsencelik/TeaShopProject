using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface IShopService : IGenericService<Shop>
    {
        void TChangeShopStatus(int id);
        void TChangeHomeStatus(int id);
        List<Shop> TGetLast3Shops();
        List<Shop> TGetActiveShops();
    }
}