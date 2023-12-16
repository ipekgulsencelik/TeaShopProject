using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDAL _socialMediaDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }

		public void TChangeHomeStatus(int id)
		{
			_socialMediaDAL.ChangeHomeStatus(id);
		}

		public void TChangeSocialMediaStatus(int id)
        {
            _socialMediaDAL.ChangeSocialMediaStatus(id);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialMediaDAL.Delete(entity);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialMediaDAL.GetByID(id);
        }

        public List<SocialMedia> TGetLast4ActiveSocialMedia()
        {
            return _socialMediaDAL.GetLast4ActiveSocialMedia();
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialMediaDAL.GetListAll();
        }

        public void TInsert(SocialMedia entity)
        {
            _socialMediaDAL.Insert(entity);
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaDAL.Update(entity);
        }
    }
}