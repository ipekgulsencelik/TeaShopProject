﻿using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFSocialMediaDAL : GenericRepository<SocialMedia>, ISocialMediaDAL
    {
        public EFSocialMediaDAL(TeaContext context) : base(context)
        {
        }

		public void ChangeHomeStatus(int id)
		{
			var context = new TeaContext();
			var socialMedia = context.SocialMedias.Where(x => x.SocialMediaID == id).FirstOrDefault();
			if (socialMedia.IsHome == true)
			{
				socialMedia.IsHome = false;
			}
			else
			{
				socialMedia.IsHome = true;
			}
			context.Update(socialMedia);
			context.SaveChanges();
		}

		public void ChangeSocialMediaStatus(int id)
        {
            var context = new TeaContext();
            var socialMedia = context.SocialMedias.Where(x => x.SocialMediaID == id).FirstOrDefault();
            if (socialMedia.SocialMediaStatus == true)
            {
                socialMedia.SocialMediaStatus = false;
            }
            else
            {
                socialMedia.SocialMediaStatus = true;
            }
            context.Update(socialMedia);
            context.SaveChanges();
        }

        public List<SocialMedia> GetLast4ActiveSocialMedia()
        {
            var context = new TeaContext();
            var accountCount = context.SocialMedias.Where(x => x.SocialMediaStatus == true && x.IsHome == true).Count();
            var values = context.SocialMedias.Where(x => x.SocialMediaStatus == true && x.IsHome == true).ToList();
            if (accountCount <= 4)
            {
                values = context.SocialMedias.Where(x => x.SocialMediaStatus == true && x.IsHome == true).OrderByDescending(x => x.SocialMediaID).ToList();
            }
            else
            {
                values = context.SocialMedias.Where(x => x.SocialMediaStatus == true && x.IsHome == true).OrderByDescending(x => x.SocialMediaID).Take(4).ToList();
            }
            return values;
        }
    }
}