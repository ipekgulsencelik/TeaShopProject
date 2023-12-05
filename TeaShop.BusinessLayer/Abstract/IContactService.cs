using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        void TChangeContactStatus(int id);
        Contact TGetActiveContact();
    }
}