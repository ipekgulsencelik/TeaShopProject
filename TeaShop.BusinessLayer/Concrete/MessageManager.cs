using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void TChangeMessageStatus(int id)
        {
            _messageDAL.ChangeMessageStatus(id);
        }

        public void TDelete(Message entity)
        {
            _messageDAL?.Delete(entity);
        }

        public Message TGetByID(int id)
        {
            return _messageDAL.GetByID(id);
        }

        public List<Message> TGetListAll()
        {
            return _messageDAL.GetListAll();
        }

        public void TInsert(Message entity)
        {
            _messageDAL.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDAL.Update(entity);
        }
    }
}