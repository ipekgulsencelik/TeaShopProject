using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFSubscribeDAL : GenericRepository<Subscribe>, ISubscribeDAL
    {
        public EFSubscribeDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeSubscribeStatus(int id)
        {
            var context = new TeaContext();
            var subscribe = context.Subscribes.Where(x => x.SubscribeID == id).FirstOrDefault();
            if (subscribe.SubscribeStatus == true)
            {
                subscribe.SubscribeStatus = false;
            }
            else
            {
                subscribe.SubscribeStatus = true;
            }
            context.Update(subscribe);
            context.SaveChanges();
        }
    }
}