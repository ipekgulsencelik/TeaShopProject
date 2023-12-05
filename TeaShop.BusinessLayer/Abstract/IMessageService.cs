using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        void TChangeMessageStatus(int id);
    }
}