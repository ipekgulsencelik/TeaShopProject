using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFMessageDAL : GenericRepository<Message>, IMessageDAL
    {
        public EFMessageDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeMessageStatus(int id)
        {
            var context = new TeaContext();
            var message = context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
            if (message.MessageStatus == true)
            {
                message.MessageStatus = false;
            }
            else
            {
                message.MessageStatus = true;
            }
            context.Update(message);
            context.SaveChanges();
        }
    }
}