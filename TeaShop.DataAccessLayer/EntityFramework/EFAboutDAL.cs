using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFAboutDAL : GenericRepository<About>, IAboutDAL
    {
        public EFAboutDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeHomeStatus(int id)
        {
            var context = new TeaContext();
            var about = context.Abouts.Where(x => x.AboutID == id).FirstOrDefault();
            if (about.IsHome == true)
            {
                about.IsHome = false;
            }
            else
            {
                about.IsHome = true;
            }
            context.Update(about);
            context.SaveChanges();
        }

        public void ChangeAboutStatus(int id)
        {
            var context = new TeaContext();
            var about = context.Abouts.Where(x => x.AboutID == id).FirstOrDefault();
            if (about.AboutStatus == true)
            {
                about.AboutStatus = false;
            }
            else
            {
                about.AboutStatus = true;
            }
            context.Update(about);
            context.SaveChanges();
        }

        public List<About> GetActiveAbouts()
        {
            var context = new TeaContext();
            var values = context.Abouts.Where(x => x.AboutStatus == true).ToList();
            return values;
        }

        public List<About> GetLast3Abouts()
        {
            var context = new TeaContext();
            var aboutCount = context.Abouts.Where(x => x.AboutStatus == true && x.IsHome == true).Count();
            var values = context.Abouts.Where(x => x.AboutStatus == true && x.IsHome == true).ToList();
            if (aboutCount <= 3)
            {
                values = context.Abouts.Where(x => x.AboutStatus == true && x.IsHome == true).OrderByDescending(x => x.AboutID).ToList();
            }
            else
            {
                values = context.Abouts.Where(x => x.AboutStatus == true && x.IsHome == true).OrderByDescending(x => x.AboutID).Take(3).ToList();
            }
            return values;
        }

        public void ChangeFooterStatus(int id)
        {
            var context = new TeaContext();
            var about = context.Abouts.Where(x => x.AboutID == id).FirstOrDefault();
            if (about.IsFooter == true)
            {
                about.IsFooter = false;
            }
            else
            {
                about.IsFooter = true;
            }
            context.Update(about);
            context.SaveChanges();
        }

		public About GetAboutByFooterStatus()
		{
			var context = new TeaContext();
			var values = context.Abouts.Where(x => x.AboutStatus == true && x.IsFooter == true).OrderByDescending(x => x.AboutID).Take(1).FirstOrDefault();
			return values;
		}
	}
}