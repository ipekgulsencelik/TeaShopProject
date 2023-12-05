using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDAL _subscribeDAL;

        public SubscribeManager(ISubscribeDAL subscribeDAL)
        {
            _subscribeDAL = subscribeDAL;
        }

        public void TChangeSubscribeStatus(int id)
        {
            _subscribeDAL.ChangeSubscribeStatus(id);
        }

        public void TDelete(Subscribe entity)
        {
            _subscribeDAL.Delete(entity);
        }

        public Subscribe TGetByID(int id)
        {
            return _subscribeDAL.GetByID(id);
        }

        public List<Subscribe> TGetListAll()
        {
            return _subscribeDAL.GetListAll();
        }

        public void TInsert(Subscribe entity)
        {
            _subscribeDAL.Insert(entity);
        }

        public void TUpdate(Subscribe entity)
        {
            _subscribeDAL.Update(entity);
        }
    }
}