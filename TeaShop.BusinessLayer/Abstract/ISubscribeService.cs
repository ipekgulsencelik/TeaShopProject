using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface ISubscribeService : IGenericService<Subscribe>
    {
        void TChangeSubscribeStatus(int id);
    }
}