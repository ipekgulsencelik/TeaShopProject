using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFContactDAL : GenericRepository<Contact>, IContactDAL
    {
        public EFContactDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeContactStatus(int id)
        {
            var context = new TeaContext();
            var contact = context.Contacts.Where(x => x.ContactID == id).FirstOrDefault();
            if (contact.ContactStatus == true)
            {
                contact.ContactStatus = false;
            }
            else
            {
                contact.ContactStatus = true;
            }
            context.Update(contact);
            context.SaveChanges();
        }

        public Contact GetActiveContact()
        {
            var context = new TeaContext();
            var values = context.Contacts.Where(x => x.ContactStatus == true).OrderByDescending(x => x.ContactID).Take(1).FirstOrDefault();
            return (Contact)values;
        }
    }
}