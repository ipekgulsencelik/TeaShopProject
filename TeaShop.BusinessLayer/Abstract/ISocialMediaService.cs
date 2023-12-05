using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface ISocialMediaService : IGenericService<SocialMedia>
    {
        void TChangeSocialMediaStatus(int id);
        List<SocialMedia> TGetLast4ActiveSocialMedia();
    }
}