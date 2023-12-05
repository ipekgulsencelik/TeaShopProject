using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class MapManager : IMapService
    {
        private readonly IMapDAL _mapDAL;

        public MapManager(IMapDAL mapDAL)
        {
            _mapDAL = mapDAL;
        }

        public void TChangeMapStatus(int id)
        {
            _mapDAL.ChangeMapStatus(id);
        }

        public void TDelete(Map entity)
        {
            _mapDAL.Delete(entity);
        }

        public Map TGetActiveMap()
        {
            return _mapDAL.GetActiveMap();
        }

        public Map TGetByID(int id)
        {
            return _mapDAL.GetByID(id);
        }

        public List<Map> TGetListAll()
        {
            return _mapDAL.GetListAll();
        }

        public void TInsert(Map entity)
        {
            _mapDAL.Insert(entity);
        }

        public void TUpdate(Map entity)
        {
            _mapDAL.Update(entity);
        }
    }
}