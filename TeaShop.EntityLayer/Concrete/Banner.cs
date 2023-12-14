using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop.EntityLayer.Concrete
{
    public class Banner
    {
        public int BannerID { get; set; }
        public string BannerTitle { get; set; }
        public string BannerSubTitle { get; set; }
        public string BannerImageURL { get; set; }
        public bool IsHome { get; set; }
        public bool BannerStatus { get; set; }
    }
}
