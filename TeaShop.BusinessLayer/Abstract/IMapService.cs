using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface IMapService : IGenericService<Map>
    {
        void TChangeMapStatus(int id);
        Map TGetActiveMap();
    }
}