using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface IMessageDAL : IGenericDAL<Message>
    {
        void ChangeMessageStatus(int id);
    }
}