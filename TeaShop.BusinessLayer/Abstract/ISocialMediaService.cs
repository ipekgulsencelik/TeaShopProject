using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface ISocialMediaService : IGenericService<SocialMedia>
    {
        void TChangeSocialMediaStatus(int id);
		void TChangeHomeStatus(int id);
		List<SocialMedia> TGetLast4ActiveSocialMedia();
    }
}