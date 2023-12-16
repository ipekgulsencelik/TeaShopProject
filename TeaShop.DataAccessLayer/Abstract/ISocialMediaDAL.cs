using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface ISocialMediaDAL : IGenericDAL<SocialMedia>
    {
        void ChangeSocialMediaStatus(int id);
		void ChangeHomeStatus(int id);
		List<SocialMedia> GetLast4ActiveSocialMedia();
    }
}