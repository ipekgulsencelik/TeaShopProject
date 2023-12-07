using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void TChangeHomeStatus(int id)
        {
            _aboutDAL.ChangeHomeStatus(id);
        }

        public void TChangeAboutStatus(int id)
        {
            _aboutDAL.ChangeAboutStatus(id);
        }

        public void TDelete(About entity)
        {
            _aboutDAL.Delete(entity);
        }

        public List<About> TGetActiveAbouts()
        {
            return _aboutDAL.GetActiveAbouts();
        }

        public About TGetByID(int id)
        {
            return _aboutDAL.GetByID(id);
        }

        public List<About> TGetLast3Abouts()
        {
            return _aboutDAL.GetLast3Abouts();
        }

        public List<About> TGetListAll()
        {
            return _aboutDAL.GetListAll();
        }

        public void TInsert(About entity)
        {
            _aboutDAL.Insert(entity);
        }

        public void TUpdate(About entity)
        {
            _aboutDAL.Update(entity);
        }

        public void TChangeFooterStatus(int id)
        {
            _aboutDAL.ChangeFooterStatus(id);
        }

		public About TGetAboutByFooterStatus()
		{
			return _aboutDAL.GetAboutByFooterStatus();
		}
	}
}