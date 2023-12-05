using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface ISubscribeDAL : IGenericDAL<Subscribe>
    {
        void ChangeSubscribeStatus(int id);
    }
}