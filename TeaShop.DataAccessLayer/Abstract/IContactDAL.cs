using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface IContactDAL : IGenericDAL<Contact>
    {
        void ChangeContactStatus(int id);
        Contact GetActiveContact();
    }
}