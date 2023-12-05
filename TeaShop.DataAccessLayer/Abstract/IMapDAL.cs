using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface IMapDAL : IGenericDAL<Map>
    {
        void ChangeMapStatus(int id);
        Map GetActiveMap();
    }
}